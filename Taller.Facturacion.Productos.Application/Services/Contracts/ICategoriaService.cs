using System;
using System.Collections.Generic;
using Taller.Facturacion.Productos.Domain.Entities;

namespace Taller.Facturacion.Productos.Application.Services.Contracts
{
    public interface ICategoriaService
    {
        IEnumerable<Categoria> FindAll();
        Categoria FindById(int id);
        void Save(Categoria product);
        void Update(Categoria product);
        void Delete(int id);
    }
}
