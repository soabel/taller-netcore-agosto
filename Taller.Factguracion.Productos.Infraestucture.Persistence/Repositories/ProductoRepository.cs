using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Taller.Facturacion.Productos.Domain.Entities;
using Taller.Facturacion.Productos.Domain.Repositories;

namespace Taller.Facturacion.Productos.Infraestucture.Persistence.Repositories
{
    public class ProductoRepository: IProductoRepository
    {
        private readonly DatabaseContext _databaseContext;
        public ProductoRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public void Delete(int id)
        {
            var entity = _databaseContext.Productos.Find(id);
            if (entity == null)
            {
                throw new Exception("Elemento no existe");
            }
            _databaseContext.Remove(entity);
            _databaseContext.SaveChanges();
        }

        public IEnumerable<Producto> FindAll()
        {
            //return new Producto[] { new Producto { Id=1, Nombre="TV 50'", Precio=400, Stock=10, CategoriaId=1, Categoria= new Categoria{ Id=1, Nombre="Electrodomesticos" } }
            //, new Producto { Id=2, Nombre="Laptop 15' Lenovo", Precio=800, Stock=4 , CategoriaId=1, Categoria= new Categoria{ Id=1, Nombre="Computo" }  } };

            return _databaseContext
                .Productos.Include("Category")
                .ToList();

        }

        public Producto FindById(int id)
        {
            return _databaseContext.Productos.Include(p => p.Category)
                .SingleOrDefault(x => x.ProductoId == id);

            //return new Producto { ProductoId = 2, Nombre = "Laptop 15' Lenovo", Precio = 800, Stock = 4, CategoriaId = 1, Categoria = new Categoria { Id = 1, Nombre = "Computo" } };
        }

        public void Save(Producto product)
        {
            _databaseContext.Add(product);
            _databaseContext.SaveChanges();

        }

        public void Update(Producto product)
        {
            //var productoExistente = _databaseContext.Productos.Find(product.ProductoId);

            //productoExistente.Nombre = product.Nombre;
            //productoExistente.Precio = product.Precio;
            //productoExistente.CategoriaId = product.CategoriaId;
            //productoExistente.Stock = product.Stock;

            //_databaseContext.SaveChanges();

            _databaseContext.Update(product);

            _databaseContext.SaveChanges();

        }
    }
}
