namespace Mag_Blog.CoreLayer.Services.Categories;

public interface ICategoryService
{
    void CreateCategory(CreateCategoryDTO createCategoryDto);
    void EditCategory(EditCategoryDTO editCategoryDto);
    List<CategoryDTO> GatAllCategories();
    CategoryDTO GetCategoryBy(int id);
    CategoryDTO GetCategoryBy(string slug);

}