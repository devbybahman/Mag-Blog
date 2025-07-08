using Mag_Blog.CoreLayer.Services.Posts;
using Microsoft.AspNetCore.Mvc;

namespace Mag_Blog.Web.Areas.Admin.Controllers
{[Area("Admin")]
    public class PostController : BaseAdminController
    {
        private readonly IPostService _service;

        public PostController(IPostService service)
        {
            _service = service;
        }
        public ActionResult Index(int pageid=1,string title="",string categorySlug="")
        {
            var r = _service.GetPostByFilter(pageid, title, categorySlug, 20);
            return View(r);
        }

    }
}
