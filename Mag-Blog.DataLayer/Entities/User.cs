using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Mag_Blog.DataLayer.Entities;

public class User:BaseEntity
{
 
    [DisplayName("نام کاربری")]
    [Required(ErrorMessage = "{0} اجباری است")]
    public string UserName { get; set; }
    [DisplayName("نام و نام خانوادگی")]
    [Required(ErrorMessage = "{0} اجباری است")]
    public string FullName { get; set; }
    [DisplayName("رمز عبور")]
    [Required(ErrorMessage = "{0} اجباری است")]
    public string Password    { get; set; }
    public UserRole Role { get; set; }
    
    #region Relations

    public ICollection<Post> Posts { get; set; }
    public ICollection<PostComment> PostComments { get; set; }

    #endregion
}

public enum UserRole
{
    Admin,
    User,
    Author
}