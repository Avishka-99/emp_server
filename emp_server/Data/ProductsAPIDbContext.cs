using emp_server.Models;
using Microsoft.EntityFrameworkCore;

namespace emp_server.Data
{
    public class ProductsAPIDbContext : DbContext
    {
        public ProductsAPIDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Products> Products { get; set; }
    }
}
