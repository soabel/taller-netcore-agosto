using System;
using System.Collections.Generic;
using System.Linq;
using Taller.Facturacion.Productos.Domain.Dtos;
using Taller.Facturacion.Productos.Domain.Entities;
using Taller.Facturacion.Productos.Domain.Repositories;
using Taller.Facturacion.Productos.Domain.Services.Contracts;

namespace Taller.Facturacion.Productos.Domain.Services
{
    public class ProductoDomain: IProductoDomain
    {
        private readonly IGenericRepository<Producto> _productoRepository;
        public ProductoDomain(IGenericRepository<Producto> productoRepository)
        {
            _productoRepository = productoRepository;
        }

        public bool ValidarStockVenta(IEnumerable<ProductoValidarStockDto> productosValidar)
        {
            var productosIds = productosValidar.Select(p => p.ProductoId);
            var productos = _productoRepository.FindAll(p=> productosIds.Contains(p.ProductoId));

            var resultado = productos.All(p => p.Stock >= productosValidar.First(v => v.ProductoId == p.ProductoId).Cantidad);

            return resultado;

        }
    }
}
