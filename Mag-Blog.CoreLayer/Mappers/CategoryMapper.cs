using Mag_Blog.CoreLayer.DTOs.Categories;
using Mag_Blog.DataLayer.Entities;

namespace Mag_Blog.CoreLayer.Mappers;

public class CategoryMapper
{
    public static CategoryDTO Map(Category category)
    {
      return  new CategoryDTO()
        {
            MetaDescription = category.MetaDescription,
            MetaTag = category.MetaTag,
            Slug = category.Slug,
            ParentId = category.ParentId,
            Id = category.Id,
            Title = category.Title
        };
    }
    
}