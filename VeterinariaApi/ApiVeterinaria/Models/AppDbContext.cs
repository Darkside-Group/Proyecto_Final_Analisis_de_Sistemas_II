using ApiVenta.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiVeterinaria.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Producto> Productos { get; set; }
        public DbSet<Venta> Ventas { get; set; }  // Agregar la tabla de Ventas
                                                  //public DbSet<VentasDiarias> VentasDiarias { get; set; }
                                                  // public DbSet<InventarioPorMes> InventarioPorMes { get; set; }
        public DbSet<PetProfile> PetProfiles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producto>()
                .Property(p => p.Precio)
                .HasColumnType("decimal(18,2)"); // Especifica el tipo de columna y precisión

            modelBuilder.Entity<Producto>()
                .Property(p => p.Cantidad)
                .IsRequired(); // Asegúrate de que la propiedad Cantidad es requerida (puedes modificar esto según lo necesites)

            modelBuilder.Entity<VentasDiarias>()
                .Property(v => v.PrecioTotal)
                .HasColumnType("decimal(18,2)"); // Ajusta según sea necesario
        }
    }
}
