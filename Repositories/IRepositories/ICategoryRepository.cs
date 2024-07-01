using WebApplication2.Entity.Dto;
using WebApplication2.Entity.Model;
using WebApplication2.Entity.Request;

namespace WebApplication2.Repositories.IRepositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAll();
        Task<Category> GetByCategoryId(int id);
        Task<Category> Insert(CategoryRequest categoryRequest);
        Task<Category> Update(CategoryUpdateDto categoryUpdateDto);

        Task<Category> Delete(int id);
    }
}
