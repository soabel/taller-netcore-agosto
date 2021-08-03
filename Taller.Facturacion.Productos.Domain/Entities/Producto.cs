using System;
namespace Taller.Facturacion.Productos.Domain.Entities
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal PrecioUnitario { get; set; }
        public int Stock { get; set; }
        public int CategoriaId { get; set; }

        public Categoria Categoria { get; set; }
    }
}
