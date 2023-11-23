using emp_server.Dbo;
using emp_server.Models;
namespace emp_server.Contracts
{
    public interface IEmpRepository
    {
        public Task<IEnumerable<Products>> GetProducts();
        public Task CreateProduct(ProductCreation product);
        public Task<Products> GetProduct(int id);
        public Task DeleteProduct(int id);
        public Task<IEnumerable<Products>> SearchProduct(string keyword);
    }
}
