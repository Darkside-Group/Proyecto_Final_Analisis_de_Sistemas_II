using ApiVeterinaria.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class InventarioPorMesController : ControllerBase
{
    //private readonly AppDbContext _context;

    //public InventarioPorMesController(AppDbContext context)
    //{
    //    _context = context;
    //}

    //// GET: api/InventarioPorMes
    //[HttpGet]
    //public async Task<ActionResult<IEnumerable<InventarioPorMes>>> GetInventarioPorMes()
    //{
    //    return await _context.InventarioPorMes.ToListAsync();
    //}

    //// GET: api/InventarioPorMes/5
    //[HttpGet("{id}")]
    //public async Task<ActionResult<InventarioPorMes>> GetInventarioPorMes(int id)
    //{
    //    var inventario = await _context.InventarioPorMes.FindAsync(id);
    //    if (inventario == null)
    //    {
    //        return NotFound();
    //    }
    //    return inventario;
    //}

    //// POST: api/InventarioPorMes
    //[HttpPost]
    //public async Task<ActionResult<InventarioPorMes>> PostInventarioPorMes(InventarioPorMes inventario)
    //{
    //    _context.InventarioPorMes.Add(inventario);
    //    await _context.SaveChangesAsync();
    //    return CreatedAtAction(nameof(GetInventarioPorMes), new { id = inventario.Id }, inventario);
    //}

    //// PUT: api/InventarioPorMes/5
    //[HttpPut("{id}")]
    //public async Task<IActionResult> PutInventarioPorMes(int id, InventarioPorMes inventario)
    //{
    //    if (id != inventario.Id)
    //    {
    //        return BadRequest();
    //    }

    //    _context.Entry(inventario).State = EntityState.Modified;

    //    try
    //    {
    //        await _context.SaveChangesAsync();
    //    }
    //    catch (DbUpdateConcurrencyException)
    //    {
    //        if (!InventarioPorMesExists(id))
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

    //// DELETE: api/InventarioPorMes/5
    //[HttpDelete("{id}")]
    //public async Task<IActionResult> DeleteInventarioPorMes(int id)
    //{
    //    var inventario = await _context.InventarioPorMes.FindAsync(id);
    //    if (inventario == null)
    //    {
    //        return NotFound();
    //    }

    //    _context.InventarioPorMes.Remove(inventario);
    //    await _context.SaveChangesAsync();
    //    return NoContent();
    //}

    //private bool InventarioPorMesExists(int id)
    //{
    //    return _context.InventarioPorMes.Any(e => e.Id == id);
    //}
}