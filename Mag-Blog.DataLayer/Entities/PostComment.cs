using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mag_Blog.DataLayer.Entities;

public class PostComment
{
    [Key]
    public int Id { get; set; }

    public int PostId { get; set; }

    public int UserId { get; set; }

    [DisplayName("پیام")]
    [Required(ErrorMessage = "{0} اجباری است")]
    public string Text { get; set; }

    public DateTime PublishDate { get; set; }

    public DateTime? UpdateDate { get; set; }
    public DateTime CreationDate { get; set; }
    public bool IsDeleted { get; set; }

    #region Relations

    [ForeignKey("PostId")]
    public Post Post { get; set; }
 
    [ForeignKey("UserId")]
    public User User { get; set; }

    #endregion
}