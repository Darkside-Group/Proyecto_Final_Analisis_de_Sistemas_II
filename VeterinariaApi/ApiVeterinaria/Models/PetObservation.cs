using System.ComponentModel.DataAnnotations;

namespace ApiVenta.Models
{
    public class PetObservation
    {
        public int Id { get; set; } 

        [Required]
        public int PetProfileId { get; set; } 

        [Required]
        public DateTime ObservationDate { get; set; } 

        [Required]
        [StringLength(500)]
        public string ObservationText { get; set; } 
    }
}
