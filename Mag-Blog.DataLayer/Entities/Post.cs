namespace Mag_Blog.DataLayer.Entities;

public class Post
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Slug { get; set; }
    public int Visited { get; set; }
    
}