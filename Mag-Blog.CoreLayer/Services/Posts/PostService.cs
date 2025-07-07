using CodeYad_Blog.CoreLayer.Utilities;
using Mag_Blog.CoreLayer.DTOs.Posts;
using Mag_Blog.CoreLayer.Mappers;
using Mag_Blog.DataLayer.Context;
using Mag_Blog.DataLayer.Entities;

namespace Mag_Blog.CoreLayer.Services.Posts;

public class PostService : IPostService
{
    private readonly BlogCobtext _context;

    public PostService(BlogCobtext context)
    {
        _context = context;
    }

    public OperationResult CreatePost(CreatePostDTO command)
    {
        _context.Posts.Add(new Post
        {
            Title = command.Title,
            IsDeleted = false,
            Description = command.Description,
            Slug = command.Slug.ToSlug(),
            CategoryId = command.CategoryId,
            UserId = command.UserId,
            Visited = 0
        });
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
            Category = CategoryMapper.Map(r.Category)
        };
    }

    public bool IsSlugExist(string slug)
    {
        return _context.Posts.Any(p => p.Slug == slug.ToSlug());
    }
}