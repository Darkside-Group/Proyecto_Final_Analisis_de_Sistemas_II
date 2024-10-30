using ApiVeterinaria.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class VentasDiariasController : ControllerBase
{
    //private readonly AppDbContext _context;

    //public VentasDiariasController(AppDbContext context)
    //{
    //    _context = context;
    //}

    //// GET: api/VentasDiarias
    //[HttpGet]
    //public async Task<ActionResult<IEnumerable<VentasDiarias>>> GetVentasDiarias()
    //{
    //    return await _context.VentasDiarias.ToListAsync();
    //}

    //// GET: api/VentasDiarias/5
    //[HttpGet("{id}")]
    //public async Task<ActionResult<VentasDiarias>> GetVentasDiaria(int id)
    //{
    //    var ventaDiaria = await _context.VentasDiarias.FindAsync(id);
    //    if (ventaDiaria == null)
    //    {
    //        return NotFound();
    //    }
    //    return ventaDiaria;
    //}

    //// POST: api/VentasDiarias
    //[HttpPost]
    //public async Task<ActionResult<VentasDiarias>> PostVentasDiaria(VentasDiarias ventaDiaria)
    //{
    //    _context.VentasDiarias.Add(ventaDiaria);
    //    await _context.SaveChangesAsync();
    //    return CreatedAtAction(nameof(GetVentasDiaria), new { id = ventaDiaria.Id }, ventaDiaria);
    //}

    //// PUT: api/VentasDiarias/5
    //[HttpPut("{id}")]
    //public async Task<IActionResult> PutVentasDiaria(int id, VentasDiarias ventaDiaria)
    //{
    //    if (id != ventaDiaria.Id)
    //    {
    //        return BadRequest();
    //    }

    //    _context.Entry(ventaDiaria).State = EntityState.Modified;

    //    try
    //    {
    //        await _context.SaveChangesAsync();
    //    }
    //    catch (DbUpdateConcurrencyException)
    //    {
    //        if (!VentasDiariaExists(id))
    //        {
    //            return NotFound();
    //        }
    //        else
    //        {
    //            throw;
    //        }
    //    }

    //    return NoContent();
    //}

    //// DELETE: api/VentasDiarias/5
    //[HttpDelete("{id}")]
    //public async Task<IActionResult> DeleteVentasDiaria(int id)
    //{
    //    var ventaDiaria = await _context.VentasDiarias.FindAsync(id);
    //    if (ventaDiaria == null)
    //    {
    //        return NotFound();
    //    }

    //    _context.VentasDiarias.Remove(ventaDiaria);
    //    await _context.SaveChangesAsync();
    //    return NoContent();
    //}

    //private bool VentasDiariaExists(int id)
    //{
    //    return _context.VentasDiarias.Any(e => e.Id == id);
    //}
}
