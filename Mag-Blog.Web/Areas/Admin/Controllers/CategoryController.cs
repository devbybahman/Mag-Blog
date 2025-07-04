using Mag_Blog.CoreLayer.DTOs.Categories;
using Mag_Blog.CoreLayer.Services.Categories;
using Mag_Blog.Web.Areas.Admin.Models.Categories;
using Microsoft.AspNetCore.Mvc;

namespace Mag_Blog.Web.Areas.Admin.Controllers
{
    public class CategoryController : BaseAdminController
    {

        private readonly ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }
        //list of Category 
        public ActionResult Index()
        {

            return View(_service.GatAllCategories());
        }

        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(CreateCategoryViewModel cat)
        {

        }
    }
}
