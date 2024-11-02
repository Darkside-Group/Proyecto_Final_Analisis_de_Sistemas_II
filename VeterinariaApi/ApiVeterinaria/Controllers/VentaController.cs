using Microsoft.AspNetCore.Mvc;

namespace ApiVeterinaria.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using ApiVeterinaria.Models;

    [Route("api/ventas")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public VentaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("listar")]
        public async Task<ActionResult<IEnumerable<Venta>>> GetVentas()
        {
            var ventas = await (from v in _context.Ventas
                                join p in _context.Productos on v.ProductoId equals p.Id
                                select new
                                {
                                    v.Id,
                                    ProductoId = v.ProductoId,
                                    Nombre = p.Nombre,
                                    Informacion = p.Informacion,
                                    Precio = p.Precio,
                                    CantidadVendida = v.CantidadVendida,
                                    CantidadActual = p.Cantidad, // Cantidad disponible del producto
                                    FechaVenta = v.FechaVenta
                                }).ToListAsync();

            return Ok(ventas);
        }

        // POST: api/ventas/registrar
        [HttpPost]
        [Route("registrar")]
        public async Task<ActionResult<Venta>> RegistrarVenta(Venta venta)
        {
            // Verificar si el producto existe
            var producto = await _context.Productos.FindAsync(venta.ProductoId);
            if (producto == null)
            {
                return NotFound("Producto no encontrado.");
            }


            if (producto.Cantidad < venta.CantidadVendida)
            {
                return BadRequest("No hay suficiente stock del producto.");
            }

   
            producto.Cantidad -= venta.CantidadVendida; 

            // Crear la venta
            var nuevaVenta = new Venta
            {
                ProductoId = venta.ProductoId,
                CantidadVendida = venta.CantidadVendida,
                CantidadActual = producto.Cantidad,
                FechaVenta = DateTime.Now
            };

            
            _context.Ventas.Add(nuevaVenta);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetVentas), new { id = nuevaVenta.Id }, nuevaVenta);
        }

    }
}