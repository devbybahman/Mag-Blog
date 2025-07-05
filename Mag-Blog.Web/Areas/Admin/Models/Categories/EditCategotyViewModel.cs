namespace Mag_Blog.Web.Areas.Admin.Models.Categories;

public class EditCategotyViewModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    
    public string Slug { get; set; }
    
    
    public string MetaTag { get; set; }
    
    public string MetaDescription { get; set; }
}