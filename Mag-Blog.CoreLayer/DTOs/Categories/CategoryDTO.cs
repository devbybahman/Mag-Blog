namespace Mag_Blog.CoreLayer.DTOs.Categories;

public class CategoryDTO
{
    public int Id { get; set; }
    public string Title { get; set; }
    
    public string Slug { get; set; }
    
    public int? ParentId  { get; set; }
    
    public string MetaTag { get; set; }
    
    public string MetaDescription { get; set; }
}