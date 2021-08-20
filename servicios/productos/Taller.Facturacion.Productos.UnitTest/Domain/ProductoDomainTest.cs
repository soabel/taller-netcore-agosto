using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using Taller.Facturacion.Productos.Domain.Dtos;
using Taller.Facturacion.Productos.Domain.Entities;
using Taller.Facturacion.Productos.Domain.Repositories;
using Taller.Facturacion.Productos.Domain.Services;
using Xunit;

namespace Taller.Facturacion.Productos.UnitTest.Domain
{
    public class ProductoDomainTest
    {
        #region Property  
        public Mock<IGenericRepository<Producto>> mock = new Mock<IGenericRepository<Producto>>();
        #endregion


        [Fact]
        public void validarStockVenta_OK()
        {
            //A: Arrange

            var domain = new ProductoDomain(mock.Object);
            var productosValidar = new List<ProductoValidarStockDto>();

            productosValidar.Add(new ProductoValidarStockDto { ProductoId = 1, Cantidad = 7 });
            var productoIds = productosValidar.Select(x => x.ProductoId);

            var productos = new List<Producto>() { new Producto { ProductoId=1, Stock=4 } };

            mock.Setup(p => p.FindAll(x=> productoIds.Contains(x.ProductoId), null)).Returns(productos );

            var expected = false;

            //A: Act

            var actual = domain.ValidarStockVenta(productosValidar);

            //A: Assert

            Assert.Equal(expected, actual);

        }
    }
}
