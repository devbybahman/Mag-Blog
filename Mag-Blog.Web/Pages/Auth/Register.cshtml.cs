using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using CodeYad_Blog.CoreLayer.Utilities;
using Mag_Blog.CoreLayer.DTOs.Users;
using Mag_Blog.CoreLayer.Services.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Mag_Blog.Web.Pages.Auth;
[ValidateAntiForgeryToken]
[BindProperties]
public class Register : PageModel
{
    private readonly IUserService _userService;
    
    #region ViewModel

    [DisplayName("نام کاربری")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    public string UserName { get; set; }
    [DisplayName("نام کامل")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    public string FullName { get; set; }
    [DisplayName("رمزعبور")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    [MinLength(6,ErrorMessage = "{0} باید بیشتر از 5 کاراکتر باشد")]
    public string Password { get; set; }

    #endregion

    public Register(IUserService userService)
    {
        _userService = userService;
    }
    public void OnGet()
    {
      
    }

    public IActionResult OnPost()
    {
        var r = _userService.Register(new UserRegisterDTO
        {
            UserName = UserName,
            FullName = FullName,
            Password = Password

        });
        if (r.Status==OperationResultStatus.Error)
        {
            ModelState.AddModelError("UserName",r.Message);
            return Page();
        }

        return RedirectToPage("Login");
    }

}