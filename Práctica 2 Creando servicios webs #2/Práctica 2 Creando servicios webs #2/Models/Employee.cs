using System.ComponentModel.DataAnnotations;

namespace Práctica_2_Creando_servicios_webs__2.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string Name { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "El salario no puede ser negativo.")]
        public decimal Salary { get; set; }

        public string Position { get; set; }
    }
}
