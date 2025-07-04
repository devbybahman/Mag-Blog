using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Mag_Blog.CoreLayer.DTOs.Categories;

namespace Mag_Blog.Web.Areas.Admin.Models.Categories;

public class CreateCategoryViewModel
{
    [DisplayName("عنوان")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    public string Title { get; set; }
    [DisplayName("slug")]
    [Required(ErrorMessage = "{0} را وارد کنید")]   
    public string Slug { get; set; }
    
    public int? ParentId  { get; set; }
    [DisplayName("MetaTag (با کاما از هم جداکنید)")]
    public string MetaTag { get; set; }
    
    public string MetaDescription { get; set; }
    public static CreateCategoryDTO MapViewmodel(CreateCategoryViewModel viewModel)
    {
        return new CreateCategoryDTO()
        {
            Title = viewModel.Title,
            Slug = viewModel.Slug,
            MetaDescription = viewModel.MetaDescription,
            MetaTag = viewModel.MetaTag
        };
    }
}

