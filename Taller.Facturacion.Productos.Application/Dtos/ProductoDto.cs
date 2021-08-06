using System;
namespace Taller.Facturacion.Productos.Application.Dtos
{
    public class ProductoDto
    {
        public int ProductoId { get; set; }
        public string Nombre { get; set; }
        public int Stock { get; set; }
        public string Categoria { get; set; }
    }
}

