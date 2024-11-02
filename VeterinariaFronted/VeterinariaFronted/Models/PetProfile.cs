using System.ComponentModel.DataAnnotations;
using VentaFronted.Models;

namespace VeterinariaFronted.Models
{
    public class PetProfile
    {
        public int Id { get; set; } // Clave primaria

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Required]
        [Range(0, 50)] // Ajusta el rango según las edades esperadas
        public int Edad { get; set; }

        [Required]
        [StringLength(50)]
        public string Raza { get; set; }

        [Required]
        [Range(0, 100)] // Ajusta el rango según los pesos esperados
        public double Peso { get; set; }

        public string Observaciones { get; set; }

        public string Medicamento { get; set; }

        public DateTime? ProximaCita { get; set; }

        public double GastoDelDia { get; set; }

        [Required]
        [StringLength(100)]
        public string NombreDueno { get; set; }

        [Required]
        [StringLength(15)] // Ajusta la longitud según el formato del teléfono
        public string Telefono { get; set; }

        [Required]
        [StringLength(20)]
        public string Dpi { get; set; }

        [Required]
        [Range(0, 100)] // Ajusta el rango según las edades esperadas
        public int EdadDueno { get; set; }

        // Colección de observaciones relacionadas
        public List<PetObservation> Observations { get; set; } = new List<PetObservation>();
        public List<CitaDeMascota> Citas { get; set; } = new List<CitaDeMascota>();

    }
}
