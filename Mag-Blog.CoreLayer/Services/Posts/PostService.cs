using CodeYad_Blog.CoreLayer.Utilities;
using Mag_Blog.CoreLayer.DTOs.Posts;
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
        _context.Posts.Add(new Post()
        {
            Title = command.Title,
             IsDeleted = false,
            Description = command.Description,
            Slug = command.Slug.ToSlug(),
         CategoryId   = command.CategoryId,
         UserId = command.UserId,
         Visited = 0
        });
        _context.SaveChanges();
        return OperationResult.Success();

    }

    public OperationResult EditPost(EditPostDTO command)
    {
        throw new NotImplementedException();
    }

    public PostDto GetPostById(int id)
    {
        throw new NotImplementedException();
    }

    public bool IsSlugExist(string slug)
    {
        throw new NotImplementedException();
    }
}