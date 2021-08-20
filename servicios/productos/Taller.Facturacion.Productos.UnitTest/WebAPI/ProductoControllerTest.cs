using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Taller.Facturacion.Productos.Application.Services.Contracts;
using Taller.Facturacion.Productos.Domain.Dtos;
using Taller.Facturacion.Productos.WebAPI.Controllers;
using Xunit;

namespace Taller.Facturacion.Productos.UnitTest.WebAPI
{
    public class ProductoControllerTest
    {
        #region Property  
        public Mock<IProductoService> mock = new Mock<IProductoService>();
        #endregion


        [Fact]
        public void validarStockVenta_OK() {
            //A: Arrange

            var controller = new ProductosController(mock.Object);
            var productosValidar = new List<ProductoValidarStockDto>();

            productosValidar.Add(new ProductoValidarStockDto { ProductoId = 1, Cantidad = 7 });

            mock.Setup(p => p.ValidarStockVenta(productosValidar)).Returns(true);

            var expected = true;

            //A: Act

            var result = controller.validarStockVenta(productosValidar);

            //A: Assert

            Assert.Equal(expected, (result as OkObjectResult).Value);

        }
    }
}
