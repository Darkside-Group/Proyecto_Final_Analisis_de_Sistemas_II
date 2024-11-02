using System.ComponentModel.DataAnnotations;

namespace ApiVeterinaria.Models
{
    public class Venta
    {
        [Key]
        public int Id { get; set; }
        public int ProductoId { get; set; }
        public int CantidadVendida { get; set; }
        public int CantidadActual { get; set; }
        public DateTime FechaVenta { get; set; }
    }

}
