using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderManagement.API.Data;
using OrderManagement.Shared.DTOs;
using OrderManagement.Shared.Entities;

namespace OrderManagement.API.Controllers
{
    [ApiController]
    [Route("/api/typepayment")]
    public class TypePaymentController : ControllerBase
    {
        private readonly DataContext _context;
        public TypePaymentController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTypePayment() {
            var typePaymentList = await _context.PaymentType.ToListAsync();
            if (typePaymentList == null)
            {
                return BadRequest();
            }
            return Ok(typePaymentList);
        }

        [HttpPost]
        public async Task<IActionResult> PostTypePayment(TypePaymentDTO typePayment)
        {
            var existTypePayment = await _context.PaymentType.FirstOrDefaultAsync(x => x.Description == typePayment.Description);
            if (existTypePayment != null)
            {
                return BadRequest("El registro ya existe");
            }

            PaymentType newTypePayment = new()
            {
                Description = typePayment.Description
            };
            _context.Add(newTypePayment);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> PutTypePayment(TypePaymentDTO typePayment)
        {
            var typePaymentFind = await _context.PaymentType.FirstOrDefaultAsync(x => x.Id == typePayment.Id);
            if (typePaymentFind == null)
            {
                return NotFound("No se encuentra el registro");
            }

            typePaymentFind.Description = typePayment.Description;
            _context.Update(typePaymentFind);
            await _context.SaveChangesAsync();
            return Ok(typePaymentFind);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteTypePayment(int id)
        {
            var typePaymentFind = await _context.PaymentType.FirstOrDefaultAsync(x => x.Id == id);
            if (typePaymentFind == null)
            {
                return NotFound("No se encuentra el registro");
            }

            _context.Remove(typePaymentFind);
            await _context.SaveChangesAsync();
            return Ok();
        }

    }
}
