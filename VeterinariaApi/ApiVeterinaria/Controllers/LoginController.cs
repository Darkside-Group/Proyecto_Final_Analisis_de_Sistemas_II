using ApiVenta.Models;
using ApiVeterinaria.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiVeterinaria.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LoginController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("crear")]
        public async Task<ActionResult<User>> CreateUser([FromBody] User user)
        {
            // Validar entrada
            if (user == null || string.IsNullOrWhiteSpace(user.FirstName) || string.IsNullOrWhiteSpace(user.LastName) ||
                string.IsNullOrWhiteSpace(user.Username) || string.IsNullOrWhiteSpace(user.Password))
            {
                return BadRequest("El usuario es inválido.");
            }

            // Verificar si el RoleId es válido
            var roleExists = await _context.Roles.AnyAsync(r => r.Id == user.RoleId);
            if (!roleExists)
            {
                return BadRequest("El rol no existe.");
            }

            // Agregar el nuevo usuario a la base de datos
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            // Retornar el usuario creado
            return CreatedAtAction(nameof(CreateUser), user);
        }


        // POST: api/auth/login
        [HttpPost("login")]
        public async Task<ActionResult<object>> Login([FromBody] LoginRequest loginRequest)
        {
            // Validar entrada
            if (loginRequest == null || string.IsNullOrWhiteSpace(loginRequest.Username) || string.IsNullOrWhiteSpace(loginRequest.Password))
            {
                return BadRequest("El nombre de usuario y la contraseña son requeridos.");
            }

            // Buscar el usuario por nombre de usuario
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Username == loginRequest.Username && u.Password == loginRequest.Password);

            if (user == null)
            {
                return Unauthorized("Usuario o contraseña incorrectos.");
            }

            // Si el usuario existe y la contraseña es correcta
            return Ok(new
            {
                Message = "Usuario recuperado con éxito.",
                User = user
            });
        }


    }
}