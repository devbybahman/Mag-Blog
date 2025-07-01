using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Mag_Blog.CoreLayer.Services.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Mag_Blog.Web.Pages.Auth;

[ValidateAntiForgeryToken]
public class Login : PageModel
{
    private readonly IUserService _userService;

    public Login(IUserService userService)
    {
        _userService = userService;
    }

    #region ViewModel

    [DisplayName("نام کاربری")]
    [Required(ErrorMessage = " {0} را وارد کنید")]
    public string UserName { get; set; }
    [DisplayName("رمزعبور")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    [MinLength(6,ErrorMessage = "{0} باید بیشتر از 5 کاراکتر باشد")]
    public string Password { get; set; }
    

    #endregion
    public void OnGet()
    {
      
    }
}