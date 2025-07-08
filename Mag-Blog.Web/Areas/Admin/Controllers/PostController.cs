using Microsoft.AspNetCore.Mvc;

namespace Mag_Blog.Web.Areas.Admin.Controllers
{
    public class PostController : BaseAdminController
    {
        // GET: PostController
        public ActionResult Index()
        {
            return View();
        }

    }
}
