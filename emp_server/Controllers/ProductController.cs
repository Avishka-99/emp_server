using emp_server.Contracts;
using emp_server.Data;
using emp_server.Dbo;
using emp_server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace emp_server.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : Controller
    {
        private readonly IEmpRepository emp_repository;
        //private readonly ProductsAPIDbContext dbContext;
        public ProductController(IEmpRepository _emp_repository) => emp_repository = _emp_repository;
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await emp_repository.GetProducts();
            return Ok(products);
            //return Ok(await dbContext.Products.ToListAsync());
            //return View();
        }
        /*public ProductController(ProductsAPIDbContext dbContext )
        {
              this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            return Ok(await dbContext.Products.ToListAsync());
            //return View();
        }*/
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] ProductCreation addProductRequest)
        {
            /*var product = new Products()
            {
                Id = Guid.NewGuid(),
                Name = addProductRequest.Name,
                Price = addProductRequest.Price,
                Quantity = addProductRequest.Quantity,
            };
            Console.WriteLine(product);
            await dbContext.Products.AddAsync(product);
            await dbContext.SaveChangesAsync();
            return Ok(product);*/
            try
            {
                await emp_repository.CreateProduct(addProductRequest);
                return Ok();
                //return CreatedAtRoute("CompanyById", new { id = createdProduct.Id }, createdProduct);
            }
            catch (Exception ex)
            {
                return StatusCode(500,ex.Message);
            }
            

        }
        /*
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
    }*/
    }
}
