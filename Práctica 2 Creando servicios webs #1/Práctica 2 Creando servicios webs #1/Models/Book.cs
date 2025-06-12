using System.ComponentModel.DataAnnotations;

namespace Práctica_2_Creando_servicios_webs__1.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El título es obligatorio.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "El autor es obligatorio.")]
        public string Author { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "El año debe ser un número positivo.")]
        public int Year { get; set; }

        [Required(ErrorMessage = "El género es obligatorio.")]
        public string Genre { get; set; }
    }
}
