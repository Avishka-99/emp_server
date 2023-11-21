using emp_server.Dbo;
using emp_server.Models;
namespace emp_server.Contracts
{
    public interface IEmpRepository
    {
        public Task<IEnumerable<Products>> GetProducts();
        public Task CreateProduct(ProductCreation product);
    }
}
