using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Taller.Facturacion.Ventas.Domain.Entities;
using Taller.Facturacion.Ventas.Domain.Repositories;

namespace Taller.Facturacion.Ventas.Infraestructure.Persistence.Repositories
{
    public class VentaRepository: IVentaRepository
    {
        private readonly DatabaseContext _databaseContext;
        public VentaRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public void Save(Venta venta)
        {
            _databaseContext.Ventas.Add(venta);
            _databaseContext.SaveChanges();
        }

        public IEnumerable<Venta> FindAll() {
            return _databaseContext
               .Ventas.Include("Detalle")
               .ToList();
        }
    }
}
