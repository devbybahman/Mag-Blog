using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Mag_Blog.DataLayer.Entities;

public class Category
{ 
   [Key] 
    public int Id { get; set; }
    [DisplayName("عنوان")]
    [Required(ErrorMessage = "{0} اجباری است")]
    public string Title { get; set; }
    [DisplayName("url انگلیسی")]
    [Required(ErrorMessage = "{0} اجباری است")]
    public string Slug { get; set; }
    [DisplayName("متا تگ")]
    [Required(ErrorMessage = "{0} اجباری است")]
    public string MetaTag { get; set; }
    [DisplayName("توضیح متا")]
    [Required(ErrorMessage = "{0} اجباری است")]
    public string MetaDescription { get; set; }

    public ICollection<Post> Posts { get; set; }
}