using Dapper;
using System.Data;
using WebApplication2.Entity.Model;
using WebApplication2.Repositories.IRepositories;


namespace WebApplication2.Repositories
{
    public class ProductDapperRepository : IProductRepository
    {
        private readonly IDbConnection _dbConnection;

        public ProductDapperRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public   IEnumerable<Product> GetAll()
        {
            string query = "SELECT ProductId, Name, Description, Price, Stock FROM Products;";
            return _dbConnection.Query<Product>(query);
        }

        public Product GetByProductId(int ProductId)
        {
            string query = "SELECT ProductId, Name, Description, Price, Stock FROM Products WHERE ProductId = @ProductId;";
            return _dbConnection.QuerySingleOrDefault<Product>(query, new { ProductId = ProductId });
        }

        public bool Insert(Product product)
        {
            string query = "INSERT INTO Products (Name, Description, Price, Stock) VALUES (@Name, @Description, @Price, @Stock);";
            int rowsAffected = _dbConnection.Execute(query, product);
            return rowsAffected > 0;
        }

        public bool Update(Product product)
        {
            string query = "UPDATE Products SET Name = @Name, Description = @Description, Price = @Price, Stock = @Stock WHERE ProductId = @ProductId;";
            int rowsAffected = _dbConnection.Execute(query, product);
            return rowsAffected > 0;
        }

        public bool Delete(int ProductId)
        {
            string query = "DELETE FROM Products WHERE ProductId = @ProductId;";
            int rowsAffected = _dbConnection.Execute(query, new { ProductId = ProductId });
            return rowsAffected > 0;
        }

        

    }
}
