using Dapper;
using Npgsql;
using System.Data;
using System.Data.Common;
using WebApplication2.Entity.Dto;
using WebApplication2.Entity.Model;
using WebApplication2.Entity.Request;
using WebApplication2.Repositories.IRepositories;


namespace WebApplication2.Repositories
{
    public class ProductDapperRepository : IProductRepository
    {
        private readonly NpgsqlConnection _npgsqlConnection;

        public ProductDapperRepository(NpgsqlConnection npgsqlConnection)
        {
            _npgsqlConnection = npgsqlConnection;
        }


        public async Task<IEnumerable<ProductCategoryDto>> GetAll()
        {
            string query = "SELECT * FROM product;";
            return await _npgsqlConnection.QueryAsync<ProductCategoryDto>(query);
        }

        public async Task<ProductCategoryDto> GetByProductId(int id)
        {
            string query = "SELECT * FROM product WHERE id = :id;";
            return await _npgsqlConnection.QuerySingleOrDefaultAsync<ProductCategoryDto>(query, new { id });
        }

        public async Task<ProductCategoryDto> Insert(ProductAddDto productAddDto)
        {
            try
            {
                string productQuery = @"
            INSERT INTO product (name, price, description, category_id, warranty)
            VALUES (:Name, :Price, :Description, :category_id, :Warranty);
        ";

                var id = await _npgsqlConnection.ExecuteScalarAsync<int>(productQuery, new
                {
                    productAddDto.Name,
                    productAddDto.Price,
                    productAddDto.Description,
                    productAddDto.category_id,
                    productAddDto.Warranty
                });

                if (productAddDto.ImageFiles != null && productAddDto.ImageFiles.Any())
                {
                    List<Image> images = new List<Image>();

                    foreach (var imageFile in productAddDto.ImageFiles)
                    {
                        byte[] imageData;
                        using (var memoryStream = new MemoryStream())
                        {
                            await imageFile.CopyToAsync(memoryStream);
                            imageData = memoryStream.ToArray();
                        }

                        var image = new Image
                        {
                            id = id,
                            Data = imageData
                        };

                        images.Add(image);
                    }

                    string imageQuery = @"
                INSERT INTO image (id, data, is_deleted)
                VALUES (:id, :Data, false);
            ";

                    await _npgsqlConnection.ExecuteAsync(imageQuery, images);
                }

                return new ProductCategoryDto
                {
                    Name = productAddDto.Name,
                    Price = productAddDto.Price,
                    category_id = productAddDto.category_id,
                    Description = productAddDto.Description,
                    Warranty = productAddDto.Warranty
                };
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while inserting product", ex);
            }
        }


        public async Task<ProductCategoryDto> Update(ProductUpdateDto productUpdateDto)
        {
            try
            {
                string updateQuery = @"
                UPDATE product 
                SET name = :Name, 
                    price = :Price, 
                    description = :Description, 
                    category_id = :category_id,
                    warranty = :Warranty
                WHERE  id = :id;
            ";

                await _npgsqlConnection.ExecuteAsync(updateQuery, new
                {
                    Name = productUpdateDto.Name,
                    Price = productUpdateDto.Price,
                    Description = productUpdateDto.Description,
                    category_id = productUpdateDto.category_id,
                    Warranty = productUpdateDto.Warranty,
                    id = productUpdateDto.id

                });

                if (productUpdateDto.ImageFiles != null && productUpdateDto.ImageFiles.Any())
                {
                    foreach (var imageFile in productUpdateDto.ImageFiles)
                    {
                        byte[] imageData;
                        using (var memoryStream = new MemoryStream())
                        {
                            await imageFile.CopyToAsync(memoryStream);
                            imageData = memoryStream.ToArray();
                        }

                        string imageQuery = @"
                        INSERT INTO image (id, data, is_deleted)
                        VALUES (:id, :Data, false);
                    ";
                        {

                        }
                        await _npgsqlConnection.ExecuteAsync(imageQuery, new
                        {
                            ProductId = productUpdateDto.id,
                            Data = imageData
                        });
                    }
                }
                return new ProductCategoryDto
                {
                    Name = productUpdateDto.Name,
                    Price = productUpdateDto.Price,
                    category_id = productUpdateDto.category_id,
                    Description = productUpdateDto.Description,
                    Warranty = productUpdateDto.Warranty,

                };
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while updating product", ex);
            }
        }


        public async Task<ProductCategoryDto> Delete(int id)
        {
            try
            {
                string query = @"
                UPDATE product 
                SET is_deleted = true
                WHERE id = :id;
            ";

                int affectedRows = await _npgsqlConnection.ExecuteAsync(query, new { id });

                if (affectedRows > 0)
                {
                    return new ProductCategoryDto
                    {
                        Name = null,
                        Price = 0,
                        category_id = 0,
                        Description = null,
                        Warranty = false
                    };
                }
                else
                {
                    throw new Exception("Product not found or already deleted.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while deleting product", ex);
            }
        }

    }
}









