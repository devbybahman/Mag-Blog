using Mag_Blog.CoreLayer.DTOs.Categories;
using Mag_Blog.CoreLayer.Services.Categories;
using Microsoft.AspNetCore.Mvc;

namespace Mag_Blog.Web.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {

        private readonly ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }
        
        public ActionResult Index()
        {

            return View(_service.GatAllCategories());
        }

    }
}
