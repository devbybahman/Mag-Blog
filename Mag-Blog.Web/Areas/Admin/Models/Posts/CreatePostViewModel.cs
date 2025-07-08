using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Mag_Blog.CoreLayer.DTOs.Categories;
using Microsoft.Build.Framework;

namespace Mag_Blog.Web.Areas.Admin.Models.Posts;

public class CreatePostViewModel
{    
    public int CategoryId { get; set; }
    public int? SubCategoryId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Slug { get; set; }
}