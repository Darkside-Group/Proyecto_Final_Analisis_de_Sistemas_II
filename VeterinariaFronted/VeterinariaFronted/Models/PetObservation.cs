using System.ComponentModel.DataAnnotations;

namespace VentaFronted.Models
{
    public class PetObservation
    {
        public int Id { get; set; } // Clave primaria de la observación

        [Required]
        public int PetProfileId { get; set; } // Relación con el perfil de la mascota

        [Required]
        public DateTime ObservationDate { get; set; }

        [Required]
        [StringLength(500)] 
        public string ObservationText { get; set; } 
    }
}
