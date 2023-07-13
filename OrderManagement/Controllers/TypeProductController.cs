using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderManagement.API.Data;
using OrderManagement.Shared.DTOs;
using OrderManagement.Shared.Entities;

namespace OrderManagement.API.Controllers
{
    [ApiController]
    [Route("/api/typeproduct")]
    public class TypeProductController : ControllerBase
    {
        private readonly DataContext _context;
        public TypeProductController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllTypeProduct() { 
            var typeProductList = await _context.TypeProduct.ToListAsync();
            if(typeProductList == null)
            {
                return BadRequest();
            }
            return Ok(typeProductList);
        }

        [HttpPost]
        public async Task<IActionResult> PostTypeProduct(TypeProductDTO typeProduct)
        {
            var existTypeProduct = await _context.TypeProduct.FirstOrDefaultAsync(x => x.Description == typeProduct.Description);
            if (existTypeProduct != null)
            {
                return BadRequest("El registro ya existe");
            }

            TypeProduct newTypeProduct = new()
            {
                Description = typeProduct.Description
            };
            _context.Add(newTypeProduct);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> PutTypeProduct(TypeProductDTO typeProduct)
        {
            var typeProductFind = await _context.TypeProduct.FirstOrDefaultAsync(x => x.Id == typeProduct.Id);
            if(typeProductFind == null)
            {
                return NotFound("No se encuentra el registro");
            }

            typeProductFind.Description = typeProduct.Description;
            _context.Update(typeProductFind);
            await _context.SaveChangesAsync();
            return Ok(typeProductFind);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteTypeProduct(int id)
        {
            var typeProductFind = await _context.TypeProduct.FirstOrDefaultAsync(x => x.Id == id);
            if (typeProductFind == null)
            {
                return NotFound("No se encuentra el registro");
            } 

            _context.Remove(typeProductFind);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
