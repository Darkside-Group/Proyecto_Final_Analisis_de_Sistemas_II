namespace ApiVeterinaria.Models
{
    public class VentasDiarias
    {
        public int Id { get; set; }  // Clave primaria
        public int IdProducto { get; set; }
        public Producto Producto { get; set; }
        public DateTime FechaVenta { get; set; }
        public int CantidadVendida { get; set; }
        public decimal PrecioTotal { get; set; }
    }
}
