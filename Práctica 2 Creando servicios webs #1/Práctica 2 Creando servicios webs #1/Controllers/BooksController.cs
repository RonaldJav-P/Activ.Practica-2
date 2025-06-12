using Microsoft.AspNetCore.Mvc;
using Práctica_2_Creando_servicios_webs__1.Models;
using System.ComponentModel.DataAnnotations;

namespace Práctica_2_Creando_servicios_webs__1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private static List<Book> books = new List<Book>
        {
            new Book { Id = 1, Title = "Cien Años de Soledad", Author = "Gabriel García Márquez", Year = 1967, Genre = "Realismo mágico" },
            new Book { Id = 2, Title = "Don Quijote de la Mancha", Author = "Miguel de Cervantes", Year = 1605, Genre = "Novela" }
        };

        [HttpGet]
        public IActionResult GetAllBooks()
        {
            return Ok(books);
        }

        [HttpGet("{id}")]
        public IActionResult GetBookById(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);
            if (book == null)
                return NotFound(new { message = "Libro no encontrado." });

            return Ok(book);
        }

        [HttpPost]
        public IActionResult CreateBook([FromBody] Book newBook)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            newBook.Id = books.Count > 0 ? books.Max(b => b.Id) + 1 : 1;
            books.Add(newBook);
            return CreatedAtAction(nameof(GetBookById), new { id = newBook.Id }, newBook);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] Book updatedBook)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var book = books.FirstOrDefault(b => b.Id == id);
            if (book == null)
                return NotFound(new { message = "Libro no encontrado." });

            book.Title = updatedBook.Title;
            book.Author = updatedBook.Author;
            book.Year = updatedBook.Year;
            book.Genre = updatedBook.Genre;

            return Ok(book);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);
            if (book == null)
                return NotFound(new { message = "Libro no encontrado." });

            books.Remove(book);
            return NoContent();
        }
    }
}