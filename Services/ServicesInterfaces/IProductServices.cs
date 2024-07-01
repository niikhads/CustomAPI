using System.Runtime.InteropServices;
using WebApplication2.Entity.Dto;
using WebApplication2.Entity.Model;
using WebApplication2.Entity.Request;
using WebApplication2.Entity.Response;



namespace WebApplication2.Services.ServicesInterface
{
    public interface IProductService
    {

        ResponseBaseColumn GetAllProducts();
        ResponseBaseColumn GetProductById(int id);
        ResponseBaseColumn AddProduct(ProductAddDto productAddDto);  //ProductResponse 
        ResponseBaseColumn UpdateProduct(int id, ProductUpdateDto productUpdateDto); //
        ResponseBaseColumn DeleteProduct(int id);

    }
}
