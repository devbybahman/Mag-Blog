namespace Mag_Blog.CoreLayer.DTOs.Posts;

public class PostFilterDto
{
    public int PageId { get; set; }
    public int Take    { get; set; }
    public List<PostDto> Posts { get; set; }
    public string Title { get; set; }
    public string Slug { get; set; }
}