using System;
using Microsoft.EntityFrameworkCore;
using Taller.Facturacion.Productos.Domain.Entities;

namespace Taller.Facturacion.Productos.Infraestucture.Persistence
{
    public class DatabaseContext: DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
         : base(options)
        {
        }

        public DbSet<Producto> Productos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //modelBuilder.Entity<Producto>()
            //   .ToTable("Producto", "Catalogo")
            //   .Property(x => x.ProductoId).HasColumnName("Id");

            //modelBuilder.Entity<Producto>()
            //     .Property(x=> x.Precio).HasColumnName("PrecioUnitario");

            modelBuilder.Entity<Producto>(entity =>
            {
               entity.ToTable("Producto", "Catalogo");
               entity.Property(x => x.ProductoId).HasColumnName("Id");
               entity.Property(x => x.Precio).HasColumnName("PrecioUnitario");
            });

            modelBuilder.Entity<Categoria>(entity => {
                entity.ToTable("Categoria", "Catalogo");
            });

          
        }


    }
}
