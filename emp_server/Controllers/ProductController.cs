using emp_server.Data;
using emp_server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace emp_server.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : Controller
    {
        
        private readonly ProductsAPIDbContext dbContext;
        public ProductController(ProductsAPIDbContext dbContext )
        {
              this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            return Ok(await dbContext.Products.ToListAsync());
            //return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddProducts(AddProductRequest addProductRequest)
        {
            var product = new Products()
            {
                Id = Guid.NewGuid(),
                Name = addProductRequest.Name,
                Price = addProductRequest.Price,
                Quantity = addProductRequest.Quantity,
            };
            Console.WriteLine(product);
            await dbContext.Products.AddAsync(product);
            await dbContext.SaveChangesAsync();
            return Ok(product);

        }
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] Guid id)
        {
            var product = await dbContext.Products.FindAsync(id);
            if(product != null) 
            {
                dbContext.Remove(product);
                await dbContext.SaveChangesAsync();
                return Ok();
            }
            return NotFound();
        }
    }
}
