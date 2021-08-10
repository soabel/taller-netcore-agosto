using System;
using System.Collections.Generic;
using Taller.Facturacion.Productos.Domain.Entities;

namespace Taller.Facturacion.Productos.Domain.Repositories
{
    public interface ICategoriaRepository
    {
        IEnumerable<Categoria> FindAll();
        Categoria FindById(int id);
        void Save(Categoria categoria);
        void Update(Categoria categoria);
        void Delete(int id);
    }
}
