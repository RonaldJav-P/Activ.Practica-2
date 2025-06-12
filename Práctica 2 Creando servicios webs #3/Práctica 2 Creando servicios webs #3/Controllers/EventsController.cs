using Microsoft.AspNetCore.Mvc;
using Práctica_2_Creando_servicios_webs__3.Models;

namespace Práctica_2_Creando_servicios_webs__3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventsController : ControllerBase
    {
        private static List<Event> events = new List<Event>
        {
            new Event { Id = 1, Description = "Feria del libro", Location = "Santo Domingo", Date = DateTime.Today.AddDays(10) },
            new Event { Id = 2, Description = "Conferencia de tecnología", Location = "PUCMM", Date = DateTime.Today.AddDays(15) }
        };

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(events);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Event newEvent)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            newEvent.Id = events.Count > 0 ? events.Max(e => e.Id) + 1 : 1;
            events.Add(newEvent);
            return CreatedAtAction(nameof(GetAll), new { id = newEvent.Id }, newEvent);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Event updatedEvent)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingEvent = events.FirstOrDefault(e => e.Id == id);
            if (existingEvent == null)
                return NotFound(new { message = "Evento no encontrado." });

            existingEvent.Description = updatedEvent.Description;
            existingEvent.Location = updatedEvent.Location;
            existingEvent.Date = updatedEvent.Date;

            return Ok(existingEvent);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var eventToRemove = events.FirstOrDefault(e => e.Id == id);
            if (eventToRemove == null)
                return NotFound(new { message = "Evento no encontrado." });

            events.Remove(eventToRemove);
            return NoContent();
        }
    }
}
