using System;
using System.Collections.Generic;
using Taller.Facturacion.Ventas.Application.Services.Contracts;
using Taller.Facturacion.Ventas.Domain.Entities;
using Taller.Facturacion.Ventas.Domain.Repositories;

namespace Taller.Facturacion.Ventas.Application.Services
{
    public class VentaService : IVentaService
    {
        private readonly IVentaRepository _ventaRepository;

        public VentaService(IVentaRepository ventaRepository) {
            _ventaRepository = ventaRepository;
        }

        public IEnumerable<Venta> FindAll()
        {
            return _ventaRepository.FindAll();
        }

        public void Save(Venta venta)
        {
            this._ventaRepository.Save(venta);
        }
    }
}
