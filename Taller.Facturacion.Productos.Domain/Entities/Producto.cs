using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Taller.Facturacion.Productos.Domain.Entities
{
    public class Producto
    {
        public int ProductoId { get; set; }
        public string Nombre { get; set; }
        //[NotMapped]
        //public decimal Precio { get; set; }

        public decimal Precio { get; set; }
        public int Stock { get; set; }
        //[Column("CategoriaId")]
        //public int CategoryId { get; set; }

        //[ForeignKey("CategoryId")]
        //public Categoria Category { get; set; }


        public int CategoryId { get; set; }

        public Categoria Category { get; set; }
    }
}
