using System;
using System.Collections.Generic;
using Taller.Facturacion.Productos.Application.Services.Contracts;
using Taller.Facturacion.Productos.Domain.Entities;

namespace Taller.Facturacion.Productos.Application.Services
{
    public class ProductoService : IProductoService
    {
        public IEnumerable<Producto> findAll()
        {
            return new Producto[] { new Producto { Id=1, Nombre="TV 50'", PrecioUnitario=400, Stock=10, CategoriaId=1, Categoria= new Categoria{ Id=1, Nombre="Electrodomesticos" } }
            , new Producto { Id=2, Nombre="Laptop 15' Lenovo", PrecioUnitario=800, Stock=4 , CategoriaId=1, Categoria= new Categoria{ Id=1, Nombre="Computo" }  } };
        }

        public Producto findById(int id)
        {
            return new Producto { Id = 2, Nombre = "Laptop 15' Lenovo", PrecioUnitario = 800, Stock = 4, CategoriaId = 1, Categoria = new Categoria { Id = 1, Nombre = "Computo" } };
        }
    }
}
