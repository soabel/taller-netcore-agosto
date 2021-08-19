using System;
using System.Collections.Generic;
using Taller.Facturacion.Productos.Domain.Dtos;

namespace Taller.Facturacion.Productos.Domain.Services.Contracts
{
    public interface IProductoDomain
    {
        bool ValidarStockVenta(IEnumerable<ProductoValidarStockDto> productosValidar);
    }
}
