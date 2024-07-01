using Dapper;
using Npgsql;
using System.Data;
using WebApplication2.Entity.Dto;
using WebApplication2.Entity.Model;
using WebApplication2.Entity.Request;
using WebApplication2.Repositories.IRepositories;

namespace WebApplication2.Repositories
{
    public class CategoryDapperRepository : ICategoryRepository
    {
        private readonly NpgsqlConnection _dbConnection;

        public CategoryDapperRepository(NpgsqlConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            string query = "SELECT * FROM category";
             var result =  await _dbConnection.QueryAsync<Category>(query);
            return result;
        }

        public async Task<Category> GetByCategoryId(int id)
        {
            string query = "SELECT * FROM category WHERE id = :id AND is_deleted = false;";
            return await _dbConnection.QuerySingleOrDefaultAsync<Category>(query, new { id });
        }

        public async Task<Category> Insert(CategoryRequest categoryRequest)
        {
            string query = @"
            INSERT INTO category (name, is_deleted) 
            VALUES (:Name, false) ";

            int rowsAffected = await _dbConnection.ExecuteAsync(query, new {Name = categoryRequest.Name });
            return new Category
            {
                 
               Name = categoryRequest.Name

            };
        }

        public async Task<Category> Update(CategoryUpdateDto categoryUpdateDto)
        {
            string query = @"
            UPDATE category 
             SET name = :name 
               WHERE id = :id AND is_deleted = false";


            await _dbConnection.ExecuteAsync(query, new
            {
                Name = categoryUpdateDto.Name,
            //    id = categoryUpdateDto.id
            });

            return new Category
            {
          //      id = categoryUpdateDto.id,
                Name = categoryUpdateDto.Name
            };
        }

        public async Task<Category> Delete(int id)
        {
            string query = @"
            UPDATE category 
            SET is_deleted = true 
            WHERE id = :id;";

            int affectedRows = await _dbConnection.ExecuteAsync(query, new { id });

            if (affectedRows > 0)
            {
                return new Category
                {           
                    Name = null
                };
            }
            else
            {
                throw new Exception("Category not found or already deleted.");
            }
        }

    
    }


}

