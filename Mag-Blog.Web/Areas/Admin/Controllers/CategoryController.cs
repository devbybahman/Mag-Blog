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

    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Add(CreateCategoryViewModel viewModel)
    {
        if (!ModelState.IsValid) return View(viewModel);

        _service.CreateCategory(CreateCategoryViewModel.MapViewmodel(viewModel));
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
        if (r.Status == OperationResultStatus.NotFound)
        {
            ModelState.AddModelError(nameof(edit.Slug), r.Message);
            return View();
        }

        return RedirectToAction("Index");
    }
}