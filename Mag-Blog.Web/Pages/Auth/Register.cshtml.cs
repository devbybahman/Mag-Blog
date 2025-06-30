using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Mag_Blog.Web.Pages.Auth;

public class Register : PageModel
{
    public void OnGet()
    {
        ViewData["Title"] = "ثبت نام";
    }
}