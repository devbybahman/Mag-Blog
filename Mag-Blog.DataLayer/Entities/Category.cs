namespace Mag_Blog.DataLayer.Entities;

public class Category
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Slug { get; set; }
    public string MetaTag { get; set; }
    public string MetaDescription { get; set; }
}