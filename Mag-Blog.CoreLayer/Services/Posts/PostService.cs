using CodeYad_Blog.CoreLayer.Utilities;
using Mag_Blog.CoreLayer.DTOs.Posts;

namespace Mag_Blog.CoreLayer.Services.Posts;

public class PostService : IPostService
{
    public OperationResult CreatePost(CreatePostDTO command)
    {
        throw new NotImplementedException();
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