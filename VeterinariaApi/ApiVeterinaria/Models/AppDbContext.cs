using ApiVenta.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiVeterinaria.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Producto> Productos { get; set; }
        public DbSet<Venta> Ventas { get; set; }  
        public DbSet<PetProfile> PetProfiles { get; set; }

        public DbSet<PetObservation> PetObservations { get; set; }

        public DbSet<CitaDeMascota> CitasDeMascotas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producto>()
                .Property(p => p.Precio)
                .HasColumnType("decimal(18,2)"); 

            modelBuilder.Entity<Producto>()
                .Property(p => p.Cantidad)
                .IsRequired();

            modelBuilder.Entity<VentasDiarias>()
                .Property(v => v.PrecioTotal)
                .HasColumnType("decimal(18,2)");

        }
    }
}
