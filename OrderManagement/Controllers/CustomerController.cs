using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderManagement.API.Data;
using OrderManagement.Shared.DTOs;
using OrderManagement.Shared.Entities;

namespace OrderManagement.API.Controllers
{
    [ApiController]
    [Route("/api/customer")]
    public class CustomerController : ControllerBase
    {
        private readonly DataContext _context;
        public CustomerController(DataContext dataContext)
        {
            _context = dataContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomer()
        {
            var customerList = await _context.Customer.ToListAsync();
            if (!customerList.Any())
            {
                return BadRequest("No hay registros en la tabla");
            }
            return Ok(customerList);
        }

        [HttpPost]
        public async Task<IActionResult> PostCustomer(CustomerDTO customer)
        {
            var customerFind = await _context.Customer.FirstOrDefaultAsync(c => c.Description == customer.Description);
            if (customerFind != null)
            {
                return BadRequest("Ya existe esta mesa");
            }

            Customer newCustomer = new()
            {
                Description = customer.Description,
                Address = customer.Address,
                CellPhone = customer.CellPhone,

            };

            _context.Customer.Add(newCustomer);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> PutCustomer(CustomerDTO customer)
        {
            var customerFind = _context.Customer.FirstOrDefault(c => c.Id == customer.Id);
            if (customerFind == null)
            {
                return BadRequest("No se encuentra la mesa a actualizar");
            }

            customerFind.Description = customer.Description;
            customerFind.Address = customer.Address;
            customerFind.CellPhone = customer.CellPhone;

            _context.Update(customerFind);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var customerFind = _context.Customer.FirstOrDefault(c => c.Id == id);
            if (customerFind == null)
            {
                return BadRequest();
            }
            _context.Remove(customerFind);
            await _context.SaveChangesAsync();
            return Ok();
        }

    }
}
