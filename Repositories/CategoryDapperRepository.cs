using WebApplication2.Entity.Model;
using WebApplication2.Repositories.IRepositories;

namespace WebApplication2.Repositories
{
    public class CategoryDapperRepository : ICategoryRepository
    {
        private readonly IDbConnection _dbConnection;

        public CategoryDapperRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public IEnumerable<Category> GetAll()
        {
            string query = "SELECT * FROM Categories;";
            return _dbConnection.Query<Category>(query);
        }

        public Category GetByCategoryId(int CategoryId)
        {
            string query = "SELECT CategoryId, Name, Description FROM Categories WHERE CategoryId = :CategoryId;";
            return _dbConnection.QuerySingleOrDefault<Category>(query, new { CategoryId = CategoryId });
        }

        public bool Insert(Category category)
        {
            string query = "INSERT INTO Categories (Name, Description) VALUES (@Name, :Description);";
            int rowsAffected = _dbConnection.Execute(query, category);
            return rowsAffected > 0;
        }

        public bool Update(Category category)
        {
            string query = "UPDATE Categories SET Name = @Name, Description = @Description WHERE CategoryId = :CategoryId;";
            int rowsAffected = _dbConnection.Execute(query, category);
            return rowsAffected > 0;
        }

        public bool Delete(int CategoryId)
        {
            string query = "DELETE FROM Categories WHERE CategoryId = :CategoryId;";
            int rowsAffected = _dbConnection.Execute(query, new { CategoryId = CategoryId });
            return rowsAffected > 0;
        }
    }
}
