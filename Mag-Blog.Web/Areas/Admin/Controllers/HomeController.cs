using Microsoft.AspNetCore.Mvc;

namespace Mag_Blog.Web.Areas.Admin.Controllers
{
    public class HomeController : BaseAdminController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
