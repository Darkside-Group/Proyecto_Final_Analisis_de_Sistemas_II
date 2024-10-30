namespace ApiVeterinaria.Models
{
    public class Venta
    {
        public int Id { get; set; }
        public int ProductoId { get; set; }
        public int CantidadVendida { get; set; }
        public int CantidadActual { get; set; } // Asegúrate de que esta propiedad exista
        public DateTime FechaVenta { get; set; }
    }

}
