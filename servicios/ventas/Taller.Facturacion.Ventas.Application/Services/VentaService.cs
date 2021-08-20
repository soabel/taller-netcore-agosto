using System;
using System.Linq;
using System.Collections.Generic;
using Taller.Facturacion.Ventas.Application.Services.Contracts;
using Taller.Facturacion.Ventas.Domain.Entities;
using Taller.Facturacion.Ventas.Domain.Repositories;
using Taller.Facturacion.Ventas.Application.Dtos;
using System.Threading.Tasks;

namespace Taller.Facturacion.Ventas.Application.Services
{
    public class VentaService : IVentaService
    {
        private readonly IVentaRepository _ventaRepository;
        private readonly IProductoService _productoService;

        public VentaService(IVentaRepository ventaRepository, IProductoService productoService) {
            _ventaRepository = ventaRepository;
            _productoService = productoService;
        }

        public IEnumerable<Venta> FindAll()
        {
            return _ventaRepository.FindAll();
        }

        public async Task Save(Venta venta)
        {

            var productosValidar = venta.Detalle.Select(x => new ProductoValidarStockDto { ProductoId = x.ProductoId, Cantidad = x.Cantidad });

            var stockValido = await _productoService.ValidarStockVenta(productosValidar);
            if (!stockValido)
                throw new ApplicationException("No hay stock suficiente para los productos a vender. ");

            this._ventaRepository.Save(venta);
        }
    }
}
