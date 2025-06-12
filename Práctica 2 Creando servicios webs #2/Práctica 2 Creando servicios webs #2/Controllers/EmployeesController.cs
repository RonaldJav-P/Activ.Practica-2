using Microsoft.AspNetCore.Mvc;
using Práctica_2_Creando_servicios_webs__2.Models;

namespace Práctica_2_Creando_servicios_webs__2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private static List<Employee> employees = new List<Employee>
        {
            new Employee { Id = 1, Name = "Maria Del Carmen", Salary = 30000, Position = "Administrador" },
            new Employee { Id = 2, Name = "Ana Gómez", Salary = 25000, Position = "Analista" }
        };

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var emp = employees.FirstOrDefault(e => e.Id == id);
            if (emp == null)
                return NotFound(new { message = "Empleado no encontrado." });

            return Ok(emp);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Employee newEmp)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            newEmp.Id = employees.Count > 0 ? employees.Max(e => e.Id) + 1 : 1;
            employees.Add(newEmp);
            return CreatedAtAction(nameof(GetById), new { id = newEmp.Id }, newEmp);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Employee updatedEmp)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var emp = employees.FirstOrDefault(e => e.Id == id);
            if (emp == null)
                return NotFound(new { message = "Empleado no encontrado." });

            emp.Name = updatedEmp.Name;
            emp.Salary = updatedEmp.Salary;
            emp.Position = updatedEmp.Position;

            return Ok(emp);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var emp = employees.FirstOrDefault(e => e.Id == id);
            if (emp == null)
                return NotFound(new { message = "Empleado no encontrado." });

            employees.Remove(emp);
            return NoContent();
        }
    }
}
