using System;
using System.Collections.Generic;
using Taller.Facturacion.Productos.Application.Dtos;
using Taller.Facturacion.Productos.Domain.Entities;
using Taller.Facturacion.Productos.Domain.Dtos;

namespace Taller.Facturacion.Productos.Application.Services.Contracts
{
    public interface IProductoService
    {
        IEnumerable<Producto> FindAll();
        Producto FindById(int id);
        void Save(Producto product);
        void Update(Producto product);
        void Delete(int id);
        bool ValidarStockVenta(IEnumerable<ProductoValidarStockDto> productosValidar);

        IEnumerable<ProductoDto> FindProductsWithCagegory();
    }
}
