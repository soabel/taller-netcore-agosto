using System;
using System.Collections.Generic;
using Taller.Facturacion.Productos.Domain.Entities;

namespace Taller.Facturacion.Productos.Domain.Repositories
{
    public interface IProductoRepository
    {
        IEnumerable<Producto> FindAll();
        Producto FindById(int id);
        void Save(Producto product);
        void Update(Producto product);
        void Delete(int id);
    }
}
