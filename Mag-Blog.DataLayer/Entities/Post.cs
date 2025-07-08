using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mag_Blog.DataLayer.Entities;

public class Post:BaseEntity
{
   

    public int UserId { get; set; }
    public int CategoryId { get; set; }
    public int? SubCategoryId { get; set; }

    [DisplayName("عنوان")]
    [Required(ErrorMessage = "{0} اجباری است")]
    public string Title { get; set; }

    [DisplayName("محتوا")]
    [Required(ErrorMessage = "{0} اجباری است")]
    public string Description { get; set; }

    [DisplayName("url انگلیسی")]
    [Required(ErrorMessage = "{0} اجباری است")]
    public string Slug { get; set; }

    public string ImageName { get; set; }
    public int Visited { get; set; }
   

    #region Relations

    [ForeignKey("UserId")] 
    public User User { get; set; }
    [ForeignKey("CategoryId")] 
    public Category Category { get; set; }
    [ForeignKey("SubCategoryId")]
    public Category SubCategory { get; set; }


    public ICollection<PostComment> PostComments { get; set; }

    #endregion
}