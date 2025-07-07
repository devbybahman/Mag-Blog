using CodeYad_Blog.CoreLayer.Utilities;
using Mag_Blog.CoreLayer.DTOs.Categories;
using Mag_Blog.CoreLayer.DTOs.Posts;

namespace Mag_Blog.CoreLayer.Services.Posts;

public interface IPostService
{
    OperationResult CreatePost(CreatePostDTO command);
    OperationResult EditPost(EditPostDTO command);
    PostDto GetPostById(int id);
    PostFilterDto GetPostByFilter(int pageid,);
    bool IsSlugExist(string slug);
}