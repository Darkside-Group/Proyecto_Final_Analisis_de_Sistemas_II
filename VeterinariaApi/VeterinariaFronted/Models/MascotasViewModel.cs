namespace VeterinariaFronted.Models
{
    public class MascotasViewModel
    {
        public int Id_Mascota { get; set; }
        public string NombreMascota { get; set; }
        public string EspecieMascota { get; set; }
        public string RazaMascota { get; set; }
        public int EdadMascota { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public decimal Precio { get; set; }
    }

}
