using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Taller.Facturacion.Productos.Domain.Entities
{
    public class Producto
    {
        public int ProductoId { get; set; }
        [MinLength(3, ErrorMessage = "El nombre debe tener al menos 3 caracteres.")]
        public string Nombre { get; set; }
        //[NotMapped]
        //public decimal Precio { get; set; }

        //[Range(0.1D,999999D, ErrorMessage = "El precio debe ser mayor a 0")]
        [Required(ErrorMessage ="El precio es requerido")]
        public decimal? Precio { get; set; }
        public int Stock { get; set; }
        //[Column("CategoriaId")]
        //public int CategoryId { get; set; }

        //[ForeignKey("CategoryId")]
        //public Categoria Category { get; set; }


        public int CategoryId { get; set; }

        public Categoria Category { get; set; }
    }
}
