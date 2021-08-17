using System;
namespace Taller.Facturacion.Ventas.Domain.Entities
{
    public class VentaDetalle
    {
        public int Id { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal Importe { get; set; }
    }
}
