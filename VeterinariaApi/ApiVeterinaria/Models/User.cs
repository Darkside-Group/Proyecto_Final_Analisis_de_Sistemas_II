using System.Data;

namespace ApiVenta.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; } // Campo para nombre de usuario
        public string Password { get; set; } // Campo para contraseña
        public int RoleId { get; set; } // ID del rol
    }
}
