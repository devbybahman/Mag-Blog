using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using CodeYad_Blog.CoreLayer.Utilities;
using Mag_Blog.CoreLayer.DTOs.Users;
using Mag_Blog.CoreLayer.Services.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Mag_Blog.Web.Pages.Auth;

[ValidateAntiForgeryToken]
[BindProperties]
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

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var r = _userService.Login(new UserLoginDTO()
        {
        UserName = this.UserName,
        Password = this.Password
        });
        if (r.Status==OperationResultStatus.NotFound)
        {
            ModelState.AddModelError("Password","نام کاربری یا رمزعبور اشتباه است");
            return Page();
        }

        TempData["success"] = true;
        return RedirectToPage("../Index");

    }
}