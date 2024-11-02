using Microsoft.EntityFrameworkCore;

namespace ApiVenta.Models
{
    public class CombinadosInformacionMascota
    {
        public int PetProfileId { get; set; }            
        public DateTime ObservationDate { get; set; }      
        public string ObservationText { get; set; }         
        public DateTime AppointmentDate { get; set; }       
        public string AppointmentDescription { get; set; }   
    }
}
