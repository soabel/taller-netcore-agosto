using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Taller.Facturacion.Productos.Application.Dtos;
using Taller.Facturacion.Productos.Application.Services.Contracts;
using Taller.Facturacion.Productos.Domain.Entities;
using Taller.Facturacion.Productos.Domain.Dtos;
using Taller.Facturacion.Productos.Domain.Repositories;
using Taller.Facturacion.Productos.Domain.Services.Contracts;
using Taller.Facturacion.Productos.Infraestructure.Core.Exceptions;
using Taller.Facturacion.Productos.Infraestucture.Persistence;

namespace Taller.Facturacion.Productos.Application.Services
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository _productoRepository;
        private readonly IProductoDomain _productoDomain;
        private readonly IMapper _mapper;
        private readonly ILogger<ProductoService> _logger;

        public ProductoService(IProductoRepository productoRepository,
            IProductoDomain productoDomain,
            IMapper mapper, ILogger<ProductoService> logger) {
            _productoRepository = productoRepository;
            _productoDomain = productoDomain;
            _mapper = mapper;
            _logger = logger;
        }

        public void Delete(int id)
        {
            this._productoRepository.Delete(id);
        }

        public IEnumerable<Producto> FindAll()
        {
            this._logger.LogInformation("call Producto FindAll");
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
            if (product.Precio <= 0) {
                throw new PriceNotValidException(product.Precio.ToString());
            }

            _productoRepository.Save(product);
        }

        public void Update(Producto product)
        {
            _productoRepository.Update(product);

        }

        public bool ValidarStockVenta(IEnumerable<ProductoValidarStockDto> productosValidar)
        {
            return _productoDomain.ValidarStockVenta(productosValidar);
        }
    }
}
