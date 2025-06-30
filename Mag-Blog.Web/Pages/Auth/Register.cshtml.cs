using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using CodeYad_Blog.CoreLayer.Utilities;
using Mag_Blog.CoreLayer.DTOs.Users;
using Mag_Blog.CoreLayer.Services.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Mag_Blog.Web.Pages.Auth;

[BindProperties]
public class Register : PageModel
{
    #region ViewModel

    [DisplayName("نام کاربری")]
    [Required(ErrorMessage = "{0} راوارد کنید")]
    public string UserName { get; set; }
    [DisplayName("نام و نام خانوادگی")]
    [Required(ErrorMessage = "{0} راوارد کنید")]
    public string FullName { get; set; }
    [DisplayName("رمزعبور")]
    
    [Required(ErrorMessage = "{0} راوارد کنید")]
    [MinLength(6,ErrorMessage = "{0} باید بیشتر از 5 کاراکتر باشد")]
    public string Password { get; set; }

    #endregion
    public void OnGet()
    {
      
    }
}