﻿using CodeYad_Blog.CoreLayer.Utilities;
using Mag_Blog.CoreLayer.DTOs.Categories;

namespace Mag_Blog.CoreLayer.Services.Categories;

public interface ICategoryService
{
    OperationResult CreateCategory(CreateCategoryDTO createCategoryDto);
    OperationResult EditCategory(EditCategoryDTO editCategoryDto);
    List<CategoryDTO> GatAllCategories();
    List<CategoryDTO> GatChildCategories(int parentId);
    CategoryDTO GetCategoryBy(int id);
    CategoryDTO GetCategoryBy(string slug);
    bool IsSlugExist(string slug);

}