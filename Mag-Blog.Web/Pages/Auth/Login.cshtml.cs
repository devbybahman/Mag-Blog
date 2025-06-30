using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Mag_Blog.Web.Pages.Auth;

public class Login : PageModel
{
    public void OnGet()
    {
        ViewData["Title"] = "ورود";
    }
}