namespace VeterinariaFronted.Models
{
    public class Venta
    {
        public int Id { get; set; }
        public int ProductoId { get; set; } // Relación con el producto
        public string Nombre { get; set; }
        public string Informacion { get; set; }
        public decimal Precio { get; set; }
        public int CantidadVendida { get; set; }
        public int CantidadActual { get; set; } // Campo que se actualiza
        public DateTime FechaVenta { get; set; }
    }
}
