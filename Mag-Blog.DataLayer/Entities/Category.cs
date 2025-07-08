using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mag_Blog.DataLayer.Entities;

public class Category:BaseEntity
{ 
   
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

    public int? ParentId { get; set; }

    #region Relations
    [InverseProperty("SubCategory")]
    public ICollection<Post> SubPosts { get; set; }
    [InverseProperty("Category")]
    public ICollection<Post> Posts { get; set; }

    #endregion
}