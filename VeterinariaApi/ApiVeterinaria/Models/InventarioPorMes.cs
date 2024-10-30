namespace ApiVeterinaria.Models
{
    public class InventarioPorMes
    {
        public int Id { get; set; }  // Clave primaria
        public int IdProducto { get; set; }
        public Producto Producto { get; set; }
        public string Mes { get; set; }
        public int CantidadInicial { get; set; }
        public int CantidadVendidaMes { get; set; }
        public int CantidadFinal { get; set; }
    }
}
