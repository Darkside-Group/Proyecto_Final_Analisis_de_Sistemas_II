namespace VeterinariaFronted.Models
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Informacion { get; set; }
        public decimal Precio { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime FechaExpiracion { get; set; }
        public int Cantidad { get; set; }  // Nuevo campo agregado

    }
}
