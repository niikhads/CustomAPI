using System.Runtime.InteropServices;
using WebApplication2.Entity.Dto;
using WebApplication2.Entity.Model;
using WebApplication2.Entity.Request;
using WebApplication2.Entity.Response;

namespace WebApplication2.Repositories.IRepositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductCategoryDto>> GetAll();
        Task<ProductCategoryDto> GetByProductId(int id);
        Task<ProductCategoryDto> Insert(ProductAddDto productAddDto);
        Task<ProductCategoryDto> Update(ProductUpdateDto productUpdateDto);

        Task<ProductCategoryDto> Delete(int id);


    }
}
