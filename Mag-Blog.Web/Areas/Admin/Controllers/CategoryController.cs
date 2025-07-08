using CodeYad_Blog.CoreLayer.Utilities;
using Mag_Blog.CoreLayer.DTOs.Categories;
using Mag_Blog.CoreLayer.Services.Categories;
using Mag_Blog.Web.Areas.Admin.Models.Categories;
using Microsoft.AspNetCore.Mvc;

namespace Mag_Blog.Web.Areas.Admin.Controllers;

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

    [Route("/admin/category/add/{parentid?}")]
    public IActionResult Add(int? parentid)
    {
        return View();
    }

    [HttpPost("/admin/category/add/{parentid?}")]
    [ValidateAntiForgeryToken]
    public IActionResult Add(int? parentid,CreateCategoryViewModel viewModel)
    {
        if (!ModelState.IsValid) return View(viewModel);
        viewModel.ParentId = parentid;
        var r=_service.CreateCategory(CreateCategoryViewModel.MapViewmodel(viewModel));
        if (r.Status != OperationResultStatus.Success)
        {
            ModelState.AddModelError(nameof(viewModel.Slug), r.Message);
            return View();
        }
        return RedirectToAction("Index");
    }

    public IActionResult Edit(int id)
    {
        var category = _service.GetCategoryBy(id);
        if (category == null) return RedirectToAction("Index");

        var viewmodel = new EditCategotyViewModel
        {
            Slug = category.Slug,
            Title = category.Title,
            MetaDescription = category.MetaDescription,
            MetaTag = category.MetaTag,
            Id = category.Id
        };

        return View(viewmodel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, EditCategotyViewModel edit)
    {
        var r = _service.EditCategory(EditCategotyViewModel.Map(edit));
        if (r.Status != OperationResultStatus.Success)
        {
            ModelState.AddModelError(nameof(edit.Slug), r.Message);
            return View();
        }

        return RedirectToAction("Index");
    }

    public JsonResult GetChildCategories(int parentid)
    {
        var r = _service.GatChildCategories(parentid);
        return new JsonResult(r);
    }
}