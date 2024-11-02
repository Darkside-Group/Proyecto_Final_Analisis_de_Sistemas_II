namespace VentaFronted.Models
{
    public class CitaDeMascota
    {
        public int Id { get; set; }                 
        public int IdPerfilMascota { get; set; }      // Identificador del perfil de la mascota (clave foránea)
        public DateTime FechaCita { get; set; }      
        public string Descripcion { get; set; }      
    }
}
