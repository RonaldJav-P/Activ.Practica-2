using Microsoft.AspNetCore.Mvc;
using Práctica_2_Creando_servicios_webs__4.Models;

namespace Práctica_2_Creando_servicios_webs__4.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InventoryController : ControllerBase
    {
        private static List<Product> inventory = new List<Product>
        {
            new Product { Id = 1, Name = "Mouse", Stock = 50 },
            new Product { Id = 2, Name = "Teclado", Stock = 30 }
        };

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(inventory);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Product product)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            product.Id = inventory.Count > 0 ? inventory.Max(p => p.Id) + 1 : 1;
            inventory.Add(product);
            return CreatedAtAction(nameof(GetAll), new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Product updatedProduct)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var product = inventory.FirstOrDefault(p => p.Id == id);
            if (product == null)
                return NotFound(new { message = "Producto no encontrado." });

            product.Name = updatedProduct.Name;
            product.Stock = updatedProduct.Stock;
            return Ok(product);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = inventory.FirstOrDefault(p => p.Id == id);
            if (product == null)
                return NotFound(new { message = "Producto no encontrado." });

            inventory.Remove(product);
            return NoContent();
        }
    }
}
