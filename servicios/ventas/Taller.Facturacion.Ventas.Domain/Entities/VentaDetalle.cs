using System;
namespace Taller.Facturacion.Ventas.Domain.Entities
{
    public class VentaDetalle
    {
        public int Id { get; set; }
        public int VentaId { get; set; }
        public int ProductoId { get; set; }
        public string ProductoNombre { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal Importe { get; set; }

        public Venta Venta { get; set; }
    }
}
