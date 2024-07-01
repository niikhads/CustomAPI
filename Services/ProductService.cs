using WebApplication2.Entity.Dto;
using WebApplication2.Entity.Model;
using WebApplication2.Entity.Request;
using WebApplication2.Entity.Response;
using WebApplication2.Repositories.IRepositories;
using WebApplication2.Services.ServicesInterface;


namespace WebApplication2.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public ResponseBaseColumn GetAllProducts()
        {
            try
            {
                var products = _repository.GetAll();
                var response = new ResponseBaseColumn();

                foreach (var product in products.Result)
                {
                    var productResponse = new ProductResponse
                    {
                        id = product.id,
                        Name = product.Name,
                        Description = product.Description,
                        Price = product.Price,



                    };

                    response = new ResponseBaseColumn
                    {
                        Data = productResponse,
                        IsSuccess = true,
                        Message = "Product retrieved successfully",
                        Status = "200"
                    };
                }

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while fetching products", ex);
            }
        }
        public ResponseBaseColumn GetProductById(int Id)
        {
            try
            {
                var product = _repository.GetByProductId(Id);

                if (product == null)
                {
                    return new ResponseBaseColumn
                    {
                        Data = null,
                        IsSuccess = false,
                        Message = "Product not found",
                        Status = "404"
                    };
                }

                var productResponse = new ProductResponse
                {
                    id = product.Result.id,
                    Name = product.Result.Name
                };

                return new ResponseBaseColumn
                {
                    Data = productResponse,
                    IsSuccess = true,
                    Message = "Product retrieved successfully",
                    Status = "200"
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"Error occurred while fetching product with ID: {Id}", ex);
            }
        }

        public ResponseBaseColumn AddProduct(ProductAddDto productAddDto)
        {
            try
            {
                var product = new Product
                {
                    Name = productAddDto.Name,
                    Price = productAddDto.Price,
                    category_id = productAddDto.category_id,
                    Description = productAddDto.Description,
                    Warranty = productAddDto.Warranty
                };


                var insertedProductTask = _repository.Insert(productAddDto);
                var insertedProduct = insertedProductTask.Result;

                if (insertedProduct == null)
                {
                    return new ResponseBaseColumn
                    {
                        Data = null,
                        IsSuccess = false,
                        Message = "Failed to add product",
                        Status = "500"
                    };
                }


                var productResponse = new ProductResponse
                {

                    Name = insertedProduct. Name,
                    Price = insertedProduct.Price,
                    category_id = insertedProduct.category_id,
                    Description = insertedProduct.Description,
                    is_Warranty = insertedProduct.Warranty

                };

                return new ResponseBaseColumn
                {
                    Data = productResponse,
                    IsSuccess = true,
                    Message = "Product added successfully",
                    Status = "200"
                };
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while adding product", ex);
            }
        }




        public ResponseBaseColumn UpdateProduct(int id, ProductUpdateDto productUpdateDto)
        {
            try
            {
                var existingProductTask = _repository.GetByProductId(id);
                var existingProduct = existingProductTask.Result;

                if (existingProduct == null)
                {
                    return new ResponseBaseColumn
                    {
                        Data = null,
                        IsSuccess = false,
                        Message = "Product not found",
                        Status = "404"
                    };
                }

                existingProduct.Name = productUpdateDto.Name;
                existingProduct.Price = productUpdateDto.Price;
                existingProduct.category_id = productUpdateDto.category_id;
                existingProduct.Description = productUpdateDto.Description;
                existingProduct.Warranty = productUpdateDto.Warranty;

                var updatedProductTask = _repository.Update(productUpdateDto);
                var updatedProduct = updatedProductTask.Result;

                if (updatedProduct == null)
                {
                    return new ResponseBaseColumn
                    {
                        Data = null,
                        IsSuccess = false,
                        Message = "Failed to update product",
                        Status = "500"
                    };
                }

                var productResponse = new ProductResponse
                {
                    id = updatedProduct.id,
                    Name = updatedProduct.Name,
                    Price = updatedProduct.Price,
                    category_id = updatedProduct.category_id,
                    Description = updatedProduct.Description,
                    is_Warranty = updatedProduct.Warranty
                };

                return new ResponseBaseColumn
                {
                    Data = productResponse,
                    IsSuccess = true,
                    Message = "Product updated successfully",
                    Status = "200"
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"Error occurred while updating product with ID: {id}", ex);
            }
        }



        public ResponseBaseColumn DeleteProduct(int id)
        {
            try
            {
                var product = _repository.GetByProductId(id);

                if (product == null)
                {
                    return new ResponseBaseColumn
                    {
                        Data = null,
                        IsSuccess = false,
                        Message = "Product not found",
                        Status = "404"
                    };
                }

                _repository.Delete(id);

                var productResponse = new ProductResponse
                {
                    id = product.Id
                };

                return new ResponseBaseColumn
                {
                    Data = productResponse,
                    IsSuccess = true,
                    Message = "Product deleted successfully",
                    Status = "200"
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"Error occurred while deleting product with ID: {id}", ex);
            }
        }


    }

}
