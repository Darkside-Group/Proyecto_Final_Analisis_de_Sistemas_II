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


        // GET: api/perfiles-mascotas/{id}/observaciones
        [HttpGet]
        [Route("{id}/observaciones")]
        public async Task<ActionResult<PetProfile>> GetPetProfileWithObservations(int id)
        {
            var petProfile = await _context.PetProfiles
                                           .Include(p => p.Observations) // Incluir observaciones
                                           .FirstOrDefaultAsync(p => p.Id == id);

            if (petProfile == null)
            {
                return NotFound();
            }

            return Ok(new
            {
                petProfile.Id,
                petProfile.Nombre,
                petProfile.Edad,
                petProfile.Raza,
                petProfile.Peso,
                petProfile.Observaciones,
                petProfile.Medicamento,
                petProfile.ProximaCita,
                petProfile.GastoDelDia,
                petProfile.NombreDueno,
                petProfile.Telefono,
                petProfile.Dpi,
                petProfile.EdadDueno,
                Observations = petProfile.Observations.Select(o => new
                {
                    o.Id,
                    o.ObservationDate,
                    o.ObservationText
                })
            });
        }

        // POST: api/perfiles-mascotas/observaciones
        [HttpPost]
        [Route("CrearObservacionesYProximaCita")]
        public async Task<ActionResult> AddObservationAndAppointment([FromBody] CombinadosInformacionMascota request)
        {
     
            var petProfile = await _context.PetProfiles.FindAsync(request.PetProfileId);
            if (petProfile == null)
            {
                return NotFound($"No se encontró un perfil de mascota con el Id {request.PetProfileId}");
            }

            // Crear nueva observación usando los datos del request
            var newObservation = new PetObservation
            {
                PetProfileId = request.PetProfileId, // Asignamos el Id del perfil de la mascota
                ObservationDate = request.ObservationDate,
                ObservationText = request.ObservationText
            };

        
            _context.PetObservations.Add(newObservation);

           
            var newAppointment = new CitaDeMascota
            {
                IdPerfilMascota = request.PetProfileId,  
                FechaCita = request.AppointmentDate,      
                Descripcion = request.AppointmentDescription 
            };

            // Agregamos la nueva cita al contexto
            _context.CitasDeMascotas.Add(newAppointment);

            // Guardamos los cambios en la base de datos
            await _context.SaveChangesAsync();

            // Retornamos una respuesta de éxito
            return Ok(new
            {
                Message = "Observación y próxima cita añadidas exitosamente",
                Observation = new
                {
                    newObservation.Id,
                    newObservation.ObservationDate,
                    newObservation.ObservationText
                },
                Appointment = new
                {
                    newAppointment.Id,
                    newAppointment.FechaCita,
                    newAppointment.Descripcion
                }
            });
        }


        // GET: api/perfiles-mascotas/{id}/citas
        [HttpGet]
        [Route("{id}/citas")]
        public async Task<ActionResult<IEnumerable<CitaDeMascota>>> GetCitasDeMascota(int id)
        {
            // Obtener las citas asociadas al perfil de la mascota
            var citas = await _context.CitasDeMascotas
                                      .Where(c => c.IdPerfilMascota == id)
                                      .ToListAsync();

            if (citas == null || !citas.Any())
            {
                return NotFound($"No se encontraron citas para el perfil de mascota con Id {id}");
            }

            return Ok(citas.Select(c => new
            {
                c.Id,
                c.IdPerfilMascota,
                c.FechaCita,
                c.Descripcion
            }));
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