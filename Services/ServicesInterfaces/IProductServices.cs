using System.Runtime.InteropServices;
using WebApplication2.Entity.Model;
using WebApplication2.Entity.Request;
using WebApplication2.Entity.Response;



namespace WebApplication2.Services.ServicesInterface
{
    public interface IProductService
    {

        List<ProductResponse> GetAllProducts();
        ProductResponse GetProductById(int ProductId);
        ProductResponse AddProduct (ProductRequest productRequest);  //ProductResponse 
        ProductResponse UpdateProduct (int ProductId ,ProductRequest productRequest); //
        ProductResponse DeleteProduct (int  ProductId);

    }
}
