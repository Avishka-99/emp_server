using Dapper;
using emp_server.Contracts;
using emp_server.Data;
using emp_server.Dbo;
using emp_server.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace emp_server.Repository
{
    public class EmpRepository : IEmpRepository
    {
        private readonly ProductsAPIDbContext _context;

        public EmpRepository(ProductsAPIDbContext context)=> _context = context;    
        
        async Task<IEnumerable<Products>> IEmpRepository.GetProducts()
        {
            var query = "SELECT * FROM Products";
            using (var connection = _context.CreateConnection())
            {
                var products = await connection.QueryAsync<Products>(query);
                return products.ToList();
            }
        }
        /*async Task IEmpRepository.CreateProduct(ProductCreation product)
        {
            var query = "INSERT INTO Products (Name,Price,Quantity) VALUES(@Name,@Price,@Quantity)";
            var parameters = new DynamicParameters(product);
            using (var connection = _context.CreateConnection())
            {
                await connection.QueryAsync<Products>(query);
            }

        }*/

        async Task  IEmpRepository.CreateProduct(ProductCreation product)
        {
            var query = "INSERT INTO Products (Name,Price,Quantity) VALUES('chocolate',3298,312)";
            var parameters = new DynamicParameters(product);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query,parameters);
                /*var id = await connection.QuerySingleAsync<Guid>(query, parameters);
                var createdProduct = new Products
                {
                    Id = id,
                    Name = product.Name,
                    Price = (float)product.Price,
                    Quantity = (int)product.Quantity
                };
                return createdProduct;*/
            }
        }
    }
}
