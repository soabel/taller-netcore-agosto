using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Taller.Facturacion.Productos.Domain.Repositories;

namespace Taller.Facturacion.Productos.Infraestucture.Persistence.Repositories
{
    public class GenericRepository<T>:IGenericRepository<T>
         where T : class
    {
        private readonly DatabaseContext _databaseContext;
        public GenericRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> FindAll(Expression<Func<T, bool>> predicate, string propertiesToInclude = "")
        {
            //return this._databaseContext.Set<T>();

            IQueryable<T> query = this._databaseContext.Set<T>().Where(predicate);
            foreach (var includeProperty in propertiesToInclude.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
            //if (predicate != null) {
            //    query.Where(predicate);
            //}
            
            return query.ToList();

        }

        public T FindById(int id)
        {
            return this._databaseContext.Set<T>().Find(id);

        }

        public void Save(T entity)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
