using System;
using System.Collections.Generic;
using Taller.Facturacion.Ventas.Domain.Entities;

namespace Taller.Facturacion.Ventas.Application.Services.Contracts
{
    public interface IVentaService
    {
        IEnumerable<Venta> FindAll();
        void Save(Venta venta);
    }
}
