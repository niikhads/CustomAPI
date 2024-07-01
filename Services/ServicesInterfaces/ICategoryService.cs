using WebApplication2.Entity.Dto;
using WebApplication2.Entity.Request;
using WebApplication2.Entity.Response;

namespace WebApplication2.Services.ServicesInterface
{
    public interface ICategoryService
    {
        Task<ResponseBaseColumn> GetAll();

         Task<ResponseBaseColumn> GetCategoryById(int id);
        Task<ResponseBaseColumn> AddCategory(CategoryRequest categoryRequest);
        Task <ResponseBaseColumn> UpdateCategory(int id, CategoryUpdateDto categoryUpdateDto);
        Task <ResponseBaseColumn> DeleteCategory(int id);
    }
}
