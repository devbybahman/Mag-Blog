using CodeYad_Blog.CoreLayer.Utilities;
using Mag_Blog.CoreLayer.DTOs.Categories;
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
        var r = _Context.Categories.Any(p => p.Title == createCategoryDto.Title || p.Slug == createCategoryDto.Slug);
        if (r)
        {
            return OperationResult.Error("این دسته بندی از قبل وجود دارد");
        }
        
        
        _Context.Categories.Add(new Category()
        
        {
        Title = createCategoryDto.Title,
        Slug = createCategoryDto.Slug,
        MetaTag = createCategoryDto.MetaTag,
            MetaDescription = createCategoryDto.MetaDescription,
        ParentId = createCategoryDto.ParentId
        });

    public OperationResult EditCategory(EditCategoryDTO editCategoryDto)
    {
        throw new NotImplementedException();
    }

    public List<CategoryDTO> GatAllCategories()
    {
        throw new NotImplementedException();
    }

    public CategoryDTO GetCategoryBy(int id)
    {
        throw new NotImplementedException();
    }

    public CategoryDTO GetCategoryBy(string slug)
    {
        throw new NotImplementedException();
    }
}