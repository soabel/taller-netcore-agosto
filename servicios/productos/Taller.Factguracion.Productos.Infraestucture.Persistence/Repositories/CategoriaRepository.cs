using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Taller.Facturacion.Productos.Domain.Entities;
using Taller.Facturacion.Productos.Domain.Repositories;

namespace Taller.Facturacion.Productos.Infraestucture.Persistence.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly DatabaseContext _databaseContext;
        public CategoriaRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public void Delete(int id)
        {
            var entity = _databaseContext.Categorias.Find(id);
            if (entity == null)
            {
                throw new Exception("Elemento no existe");
            }
            _databaseContext.Remove(entity);
            _databaseContext.SaveChanges();
        }

        public IEnumerable<Categoria> FindAll()
        {
            return _databaseContext
                .Categorias.Include(x => x.Productos)
               .ToList();
        }

        public Categoria FindById(int id)
        {
            return _databaseContext.Categorias.Include(p => p.Productos)
                .SingleOrDefault(x => x.Id == id);
        }

        public void Save(Categoria categoria)
        {
            _databaseContext.Add(categoria);
            _databaseContext.SaveChanges();
        }

        public void Update(Categoria categoria)
        {
            _databaseContext.Update(categoria);

            _databaseContext.SaveChanges();
        }
    }

}