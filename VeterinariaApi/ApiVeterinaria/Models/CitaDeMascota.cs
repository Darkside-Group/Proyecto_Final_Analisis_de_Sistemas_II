namespace ApiVenta.Models
{
    public class CitaDeMascota
    {
        public int Id { get; set; }                  
        public int IdPerfilMascota { get; set; }      
        public DateTime FechaCita { get; set; }       
        public string Descripcion { get; set; }        
    }
}
