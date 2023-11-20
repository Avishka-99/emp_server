using emp_server.Data;
using emp_server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace emp_server.Controllers
{
    [ApiController]
    [Route("api/staff")]
    public class StaffController : Controller
    {
        private readonly ProductsAPIDbContext dbContext;
        public StaffController(ProductsAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetStaff() {
            return Ok( await dbContext.Staff.ToListAsync());
        }
        [HttpPost]
        public async Task<IActionResult> AddStaff(AddStaffRequest addStaffRequest)
        {
            var staff = new Staff()
            {
                Id = Guid.NewGuid(),
                Name = addStaffRequest.Name,
                Department = addStaffRequest.Department,
                Age = addStaffRequest.Age,
                contact_no = addStaffRequest.contact_no,
                contact_email = addStaffRequest.contact_email
            };
            await dbContext.Staff.AddAsync(staff);
            await dbContext.SaveChangesAsync();
            return Ok(staff);

        }
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteStaff([FromRoute] Guid id)
        {
            var staff = await dbContext.Staff.FindAsync(id);
            if (staff != null)
            {
                dbContext.Remove(staff);
                await dbContext.SaveChangesAsync();
                return Ok();
            }
            return NotFound();
        }
    }
}
