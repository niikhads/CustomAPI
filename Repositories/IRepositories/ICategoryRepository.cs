using WebApplication2.Entity.Model;

namespace WebApplication2.Repositories.IRepositories
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAll();
        Category GetByCategoryId(int CategoryId);
        void Insert(Category category);
        void Update(Category ca0tegory);

        void Delete(int CategoryId);
    }
}
