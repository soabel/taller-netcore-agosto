using System;
using System.Collections.Generic;
using Taller.Facturacion.Ventas.Domain.Entities;

namespace Taller.Facturacion.Ventas.Domain.Repositories
{
    public interface IVentaRepository
    {
        void Save(Venta venta);
        IEnumerable<Venta> FindAll();
    }
}
