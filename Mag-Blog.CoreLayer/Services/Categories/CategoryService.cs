using CodeYad_Blog.CoreLayer.Utilities;
using Mag_Blog.CoreLayer.DTOs.Categories;
using Mag_Blog.CoreLayer.Mappers;
using Mag_Blog.DataLayer.Context;
using Mag_Blog.DataLayer.Entities;

namespace Mag_Blog.CoreLayer.Services.Categories;

public class CategoryService:ICategoryService
{
    private readonly BlogCobtext _Context;

    public CategoryService(BlogCobtext context)
    {
        _Context = context;
    }

    public OperationResult CreateCategory(CreateCategoryDTO createCategoryDto)
    {
        _Context.Categories.Add(new Category()

        {
            Title = createCategoryDto.Title,
            Slug = createCategoryDto.Slug,
            MetaTag = createCategoryDto.MetaTag,
            MetaDescription = createCategoryDto.MetaDescription,
            ParentId = createCategoryDto.ParentId
        });
        _Context.SaveChanges();
        return  OperationResult.Success();
    }

    public OperationResult EditCategory(EditCategoryDTO editCategoryDto)
    {
        var r = _Context.Categories.FirstOrDefault(p => p.Id == editCategoryDto.Id);
        if (r==null)
        {
            return OperationResult.NotFound();
        }

        r.Title = editCategoryDto.Title;
        r.MetaDescription = editCategoryDto.MetaDescription;
        r.MetaTag = editCategoryDto.MetaTag;
        r.Slug = editCategoryDto.Slug;
        _Context.Categories.Update(r);
        _Context.SaveChanges();
        return  OperationResult.Success();
    }

    public List<CategoryDTO> GatAllCategories()
    {
        return _Context.Categories.Where(p=>p.IsDeleted==false).Select(categories =>CategoryMapper.Map(categories)).ToList();
    }

    public CategoryDTO GetCategoryBy(int id)
    {
        var r = _Context.Categories.FirstOrDefault(p => p.Id == id);
        if (r==null)
        {
            return null;
        }

        return CategoryMapper.Map(r);
    }

    public CategoryDTO GetCategoryBy(string slug)
    {
        var r = _Context.Categories.FirstOrDefault(p => p.Slug==slug);
        if (r==null)
        {
            return null;
        }

        return CategoryMapper.Map(r);
    }
}