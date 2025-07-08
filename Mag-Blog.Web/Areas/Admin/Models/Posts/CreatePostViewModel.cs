using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Mag_Blog.CoreLayer.DTOs.Categories;
using Microsoft.Build.Framework;

namespace Mag_Blog.Web.Areas.Admin.Models.Posts;

public class CreatePostViewModel
{    
    [Display(Name = "انتخاب دسته بندی")]
    [System.ComponentModel.DataAnnotations.Required(ErrorMessage ="لطفا {0} را وارد کنید ")]
    public int CategoryId { get; set; }
    [Display(Name = "انتخاب زیر دسته بندی")]
    [System.ComponentModel.DataAnnotations.Required(ErrorMessage ="لطفا {0} را وارد کنید ")]
    public int? SubCategoryId { get; set; }
    [Display(Name = "عنوان")]
    [System.ComponentModel.DataAnnotations.Required(ErrorMessage ="لطفا {0} را وارد کنید ")]
    public string Title { get; set; }
    [Display(Name = "توضیحات")]
    [System.ComponentModel.DataAnnotations.Required(ErrorMessage ="لطفا {0} را وارد کنید ")]
    public string Description { get; set; }
    [Display(Name = "slug")]
    [System.ComponentModel.DataAnnotations.Required(ErrorMessage ="لطفا {0} را وارد کنید ")]
    public string Slug { get; set; }
    [Display(Name = "عکس")]
    [System.ComponentModel.DataAnnotations.Required(ErrorMessage ="لطفا {0} را وارد کنید ")]
    public IFormFile ImageFile { get; set; }
}