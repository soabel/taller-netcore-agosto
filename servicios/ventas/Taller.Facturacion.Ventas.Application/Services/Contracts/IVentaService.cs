using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Taller.Facturacion.Ventas.Domain.Entities;

namespace Taller.Facturacion.Ventas.Application.Services.Contracts
{
    public interface IVentaService
    {
        IEnumerable<Venta> FindAll();
        Task Save(Venta venta);
    }
}
