using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Taller.Facturacion.Productos.Domain.Entities
{
    [Table("Categoria", Schema ="Catalogo")]
    public class Categoria
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }

        public IEnumerable<Producto> Productos { get; set; }
    }
}
