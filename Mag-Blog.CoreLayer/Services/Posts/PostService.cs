using CodeYad_Blog.CoreLayer.Utilities;
using Mag_Blog.CoreLayer.DTOs.Posts;
using Mag_Blog.CoreLayer.Mappers;
using Mag_Blog.CoreLayer.Services.FileManager;
using Mag_Blog.DataLayer.Context;
using Mag_Blog.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace Mag_Blog.CoreLayer.Services.Posts;

public class PostService : IPostService
{
    private readonly BlogCobtext _context;
    private readonly IFileManager _file;

    public PostService(BlogCobtext context, IFileManager file)
    {
        _context = context;
        _file = file;
    }

    public OperationResult CreatePost(CreatePostDTO command)
    {
        if (command.ImageFile==null)
        {
            return OperationResult.Error();
        }

        var r = new Post()
        {
            Title = command.Title,
             IsDeleted = false,
             Description = command.Description,
            Slug = command.Slug.ToSlug(),
             CategoryId = command.CategoryId,
             UserId = command.UserId,
             Visited = 0,
        };
        if (command.ImageFile!=null)
        {
            r.ImageName = _file.SaveFile(command.ImageFile, Directories.PostImage);
        }

        _context.Posts.Add(r);
        _context.SaveChanges();
        return OperationResult.Success();
    }

    public OperationResult EditPost(EditPostDTO command)
    {
        var r = _context.Posts.FirstOrDefault(p => p.Id == command.PostId);
        if (r == null) return OperationResult.NotFound();

        r.Description = command.Description;
        r.Title = command.Title;
        r.Slug = command.Slug.ToSlug();
        r.CategoryId = command.CategoryId;

        if (command.ImageFile!=null)
        {
            r.ImageName = _file.SaveFile(command.ImageFile, Directories.PostImage);
        }
        _context.SaveChanges();
        return OperationResult.Success();
    }

    public PostDto GetPostById(int id)
    {
        var r = _context.Posts.FirstOrDefault(p => p.Id == id);
        if (r == null) return null;

        return new PostDto
        {
            Title = r.Title,
            Description = r.Description,
            UserId = r.UserId,
            Slug = r.Slug,
            CategoryId = r.CategoryId,
            CreationDate = r.CreationDate,
            Visited = r.Visited,
            PostId = r.Id,
            ImageName = r.ImageName,
            Category = CategoryMapper.Map(r.Category),
            SubCategoryId = r.SubCategoryId,
            SubCategory =r.SubCategoryId == null ? null:CategoryMapper.Map(r.SubCategory)
        };
    }

    public PostFilterDto GetPostByFilter(int pageid, string title, string categorySlug, int take)
    {
        var result = _context.Posts.Include(p=>p.Category).Include(p=>p.SubCategory).OrderByDescending(p => p.CreationDate).AsQueryable();
        if (!string.IsNullOrWhiteSpace(title)) result = result.Where(p => p.Title.Contains(title));

        if (!string.IsNullOrWhiteSpace(categorySlug)) result = result.Where(p => p.Slug == categorySlug);

        var skip = (pageid - 1) * take;
        var PageCount = result.Count() / take;
        return new PostFilterDto
        {
            Posts = result.Skip(skip).Take(take).Select(post => new PostDto
            {
                Title = post.Title,
                Description = post.Description,
                UserId = post.UserId,
                Slug = post.Slug,
                CategoryId = post.CategoryId,
                CreationDate = post.CreationDate,
                Visited = post.Visited,
                PostId = post.Id,
                ImageName = post.ImageName,
                Category = CategoryMapper.Map(post.Category)
            }).ToList(),
            PageCount = PageCount
        };
        
    }


    public bool IsSlugExist(string slug)
    {
        return _context.Posts.Any(p => p.Slug == slug.ToSlug());
    }
}