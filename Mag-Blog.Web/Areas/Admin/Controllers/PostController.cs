using CodeYad_Blog.CoreLayer.Utilities;
using Mag_Blog.CoreLayer.DTOs.Posts;
using Mag_Blog.CoreLayer.Mappers;
using Mag_Blog.CoreLayer.Services.Posts;
using Mag_Blog.Web.Areas.Admin.Models.Posts;
using Microsoft.AspNetCore.Mvc;

namespace Mag_Blog.Web.Areas.Admin.Controllers;

public class PostController : BaseAdminController
{
    private readonly IPostService _service;

    public PostController(IPostService service)
    {
        _service = service;
    }

    public ActionResult Index(int pageid = 1, string title = "", string categorySlug = "")
    {
        var r = _service.GetPostByFilter(pageid, title, categorySlug, 20);
        return View(r);
    }

    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Add(CreatePostViewModel viewModel)
    {
        if (!ModelState.IsValid) return View(viewModel);
        var r = _service.CreatePost(new CreatePostDTO
        {
            Title = viewModel.Title,
            Description = viewModel.Description,
            CategoryId = viewModel.CategoryId,
            Slug = viewModel.Slug,
            ImageFile = viewModel.ImageFile,
            SubCategoryId = viewModel.SubCategoryId==0?null:viewModel.SubCategoryId,
            UserId = User.GetUserId()
        });
        if (r.Status != OperationResultStatus.Success)
        {
            ModelState.AddModelError(nameof(viewModel.Slug), r.Message);
            return View();
        }

        return RedirectToAction("Index");
    }

    public IActionResult Edit(int id)
    {
        var posts = _service.GetPostById(id);
        if (posts == null) return RedirectToAction("Index");

        var r = new EditPostViewModel()
        {
            Title = posts.Title,
            Description = posts.Description,
            CategoryId = posts.CategoryId,
            Slug = posts.Slug,
            SubCategoryId = posts.SubCategoryId
        };

        return View(r);
    } 

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, EditPostViewModel viewModel)
    {
        if (!ModelState.IsValid)
            return View(viewModel);
        var r = _service.EditPost(new EditPostDTO
        {
            Title = viewModel.Title,
            Description = viewModel.Description,
            Slug = viewModel.Slug,
            CategoryId = viewModel.CategoryId,
            SubCategoryId = viewModel.SubCategoryId==0?null:viewModel.SubCategoryId,
            ImageFile = viewModel.ImageFile,
            PostId = id
        });
        if (r.Status != OperationResultStatus.Success)
        {
            ModelState.AddModelError(nameof(viewModel.Slug), r.Message);
            return View(viewModel);
        }

        return RedirectToAction("Index");
    }
}