using ApiVenta.Models;
using ApiVeterinaria.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiVeterinaria.Controllers // Cambiar a ApiVeterinaria para seguir el ejemplo
{
    [Route("api/perfiles-mascotas")] // Ajustado según tu formato
    [ApiController]
    public class PetProfilesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PetProfilesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/perfiles-mascotas/listar
        [HttpGet]
        [Route("listar")]
        public async Task<ActionResult<IEnumerable<PetProfile>>> GetPetProfiles()
        {
            return await _context.PetProfiles.ToListAsync();
        }

        // GET: api/perfiles-mascotas/detalles/{id}
        [HttpGet]
        [Route("detalles/{id}")]
        public async Task<ActionResult<PetProfile>> GetPetProfile(int id)
        {
            var petProfile = await _context.PetProfiles.FindAsync(id);

            if (petProfile == null)
            {
                return NotFound();
            }

            return petProfile;
        }

        // POST: api/perfiles-mascotas/crear
        [HttpPost]
        [Route("crear")]
        public async Task<ActionResult<PetProfile>> PostPetProfile(PetProfile petProfile)
        {
            _context.PetProfiles.Add(petProfile);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPetProfile), new { id = petProfile.Id }, petProfile);
        }

        // PUT: api/perfiles-mascotas/editar/{id}
        [HttpPut]
        [Route("editar/{id}")]
        public async Task<IActionResult> PutPetProfile(int id, PetProfile petProfile)
        {
            if (id != petProfile.Id)
            {
                return BadRequest();
            }

            _context.Entry(petProfile).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PetProfileExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/perfiles-mascotas/eliminar/{id}
        [HttpDelete]
        [Route("eliminar/{id}")]
        public async Task<IActionResult> DeletePetProfile(int id)
        {
            var petProfile = await _context.PetProfiles.FindAsync(id);
            if (petProfile == null)
            {
                return NotFound();
            }

            _context.PetProfiles.Remove(petProfile);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PetProfileExists(int id)
        {
            return _context.PetProfiles.Any(e => e.Id == id);
        }
    }
}