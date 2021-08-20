using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Taller.Facturacion.Ventas.Application.Dtos;

namespace Taller.Facturacion.Ventas.Application.Services.Contracts
{
    public interface IProductoService
    {
        Task<bool> ValidarStockVenta(IEnumerable<ProductoValidarStockDto> productosValidar);
    }
}
