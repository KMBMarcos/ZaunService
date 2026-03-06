using System.ComponentModel.DataAnnotations;

namespace ZaunService.Models.ViewModels
{
    public class TicketsViewModel
    {
        [Required]
        [Display(Name = "Descripción de la solicitud.")]
        public string Description { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }

        [Required]
        [Display(Name = "Servicio")]
        public int ServiceId { get; set; }
    }
}
