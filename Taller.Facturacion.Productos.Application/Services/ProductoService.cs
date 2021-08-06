using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Taller.Facturacion.Productos.Application.Dtos;
using Taller.Facturacion.Productos.Application.Services.Contracts;
using Taller.Facturacion.Productos.Domain.Entities;
using Taller.Facturacion.Productos.Domain.Repositories;
using Taller.Facturacion.Productos.Infraestucture.Persistence;

namespace Taller.Facturacion.Productos.Application.Services
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository _productoRepository;
        private readonly IMapper _mapper;


        public ProductoService(IProductoRepository productoRepository, IMapper mapper) {
            _productoRepository = productoRepository;
            _mapper = mapper;
        }

        public void Delete(int id)
        {
            this._productoRepository.Delete(id);
        }

        public IEnumerable<Producto> FindAll()
        {
            return _productoRepository.FindAll();
        }

        public Producto FindById(int id)
        {
            return _productoRepository.FindById(id);
        }

        public IEnumerable<ProductoDto> FindProductsWithCagegory()
        {
            var productos = _productoRepository.FindAll();

            //return productos.Select(p => new ProductoDto { Categoria = p.Category.Nombre,
            //    Nombre = p.Nombre, ProductoId = p.ProductoId, Stock = p.Stock });

            return _mapper.Map<IEnumerable<ProductoDto>>(productos);
        }

        public void Save(Producto product)
        {
            _productoRepository.Save(product);
        }

        public void Update(Producto product)
        {
            _productoRepository.Update(product);

        }

        
    }
}
