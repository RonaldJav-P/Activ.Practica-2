using System.ComponentModel.DataAnnotations;

namespace Práctica_2_Creando_servicios_webs__3.Models
{
    public class Event
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "La descripción es obligatoria.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "El lugar es obligatorio.")]
        public string Location { get; set; }

        [Required(ErrorMessage = "La fecha es obligatoria.")]
        [FutureDate(ErrorMessage = "La fecha del evento no puede ser en el pasado.")]
        public DateTime Date { get; set; }
    }

    public class FutureDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is DateTime date)
            {
                return date >= DateTime.Today;
            }
            return false;
        }
    }
}
