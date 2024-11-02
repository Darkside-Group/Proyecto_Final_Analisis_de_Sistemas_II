namespace VentaFronted.Models
{
    public class CombinadosInformacionMascota
    {
        public PetObservation PetObservation { get; set; }
        public CitaDeMascota CitaDeMascota { get; set; }


        //public int PetProfileId { get; set; }              // ID del perfil de la mascota
        //public DateTime ObservationDate { get; set; }      // Fecha de la observación
        //public string ObservationText { get; set; }         // Texto de la observación
        //public DateTime AppointmentDate { get; set; }       // Fecha de la próxima cita
        //public string AppointmentDescription { get; set; }   // Descripción de la cita
    }
}
