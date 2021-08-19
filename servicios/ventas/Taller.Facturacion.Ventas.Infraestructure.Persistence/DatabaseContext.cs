using System;
using Microsoft.EntityFrameworkCore;
using Taller.Facturacion.Ventas.Domain.Entities;

namespace Taller.Facturacion.Ventas.Infraestructure.Persistence
{

    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public DbSet<Venta> Ventas { get; set; }
        public DbSet<VentaDetalle> VentaDetalles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Venta>()
               .ToTable("Venta", "Ventas")
               .Property(x => x.Id);

            modelBuilder.Entity<VentaDetalle>()
              .ToTable("VentaDetalle", "Ventas")
              .Property(x => x.Id);


        }


    }
    
}
