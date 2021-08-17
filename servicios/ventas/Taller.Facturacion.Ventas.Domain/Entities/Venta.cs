using System;
using System.Collections.Generic;

namespace Taller.Facturacion.Ventas.Domain.Entities
{
    public class Venta
    {
        public int Id { get; set; }
        public int Numero { get; set; }
        public int ClienteId { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Monto { get; set; }
        public string Direccion { get; set; }

        public IEnumerable<VentaDetalle> Detalle { get; set; }
    }
}
