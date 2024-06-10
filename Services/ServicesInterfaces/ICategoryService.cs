using WebApplication2.Entity.Request;
using WebApplication2.Entity.Response;

namespace WebApplication2.Services.ServicesInterface
{
    public interface ICategoryService
    {
        List<CategoryResponse> GetAllCategories();

        ResponseBaseColumn GetCategoryById(int CategoryId);   
        CategoryResponse AddCategory (CategoryRequest categoryRequest);  
        CategoryResponse UpdateCategory (int CategoryId , CategoryRequest categoryRequest);   
        CategoryResponse DeleteCategory (int CategoryId);
    }
}
