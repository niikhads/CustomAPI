using System.Runtime.InteropServices;
using WebApplication2.Entity.Dto;
using WebApplication2.Entity.Model;

namespace WebApplication2.Repositories.IRepositories
{
    public interface IProductRepository
    {
        IEnumerable <ProductCategoryDto> GetAll();
        ProductCategoryDto GetByProductId(int ProductId );
        void Insert(ProductAddDto productAddDto  );
        void Update(ProductUpdateDto productUpdateDto );
  
        void Delete(int ProductId);
    }
}
