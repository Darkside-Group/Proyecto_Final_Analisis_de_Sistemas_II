namespace VeterinariaFronted.Models
{
    public class User 
    { public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; } // Añadido para el nombre de usuario
    public string Password { get; set; } // Nota: no se recomienda almacenar contraseñas en texto claro
    public int RoleId { get; set; }
    public Role Role { get; set; }
    }
}
