using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Taller.Facturacion.Productos.Domain.Repositories
{
    public interface IGenericRepository<T>
    {
        IEnumerable<T> FindAll(Expression<Func<T, bool>> predicate,string propertiesToInclude = "");
        T FindById(int id);
        void Save(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}
