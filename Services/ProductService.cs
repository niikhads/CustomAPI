using WebApplication2.Entity.Request;
using WebApplication2.Entity.Response;
using WebApplication2.Services.ServicesInterfaces;

namespace WebApplication2.Services
{
    public class ProductService : IProductService
    {
        public ProductResponse AddProduct(ProductRequest productRequest)
        {
            throw new NotImplementedException();
        }

        public ProductResponse DeleteProduct(int ProductId)
        {
            throw new NotImplementedException();
        }

        public List<ProductResponse> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public ProductResponse GetProductById(int ProductId)
        {
            throw new NotImplementedException();
        }

        public ProductResponse UpdateProduct(int ProductId, ProductRequest productRequest)
        {
            throw new NotImplementedException();
        }
    }
}
