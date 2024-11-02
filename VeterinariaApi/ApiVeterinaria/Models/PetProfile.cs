using System.ComponentModel.DataAnnotations;

namespace ApiVenta.Models
{
    public class PetProfile
    {
        public int Id { get; set; } 

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Required]
        [Range(0, 50)] 
        public int Edad { get; set; }

        [Required]
        [StringLength(50)]
        public string Raza { get; set; }

        [Required]
        [Range(0, 100)]
        public double Peso { get; set; }

        public string Observaciones { get; set; }

        public string Medicamento { get; set; }

        public DateTime? ProximaCita { get; set; }

        public double GastoDelDia { get; set; }

        [Required]
        [StringLength(100)]
        public string NombreDueno { get; set; }

        [Required]
        [StringLength(15)]
        public string Telefono { get; set; }

        [Required]
        [StringLength(20)]
        public string Dpi { get; set; }

        [Required]
        [Range(0, 100)] 
        public int EdadDueno { get; set; }

       
        public List<PetObservation> Observations { get; set; } = new List<PetObservation>();

    }
}
