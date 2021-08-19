using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Taller.Facturacion.Productos.Application.Dtos;
using Taller.Facturacion.Productos.Application.Services.Contracts;
using Taller.Facturacion.Productos.Domain.Entities;
using Taller.Facturacion.Productos.Domain.Dtos;
using Taller.Facturacion.Productos.WebAPI.Wrappers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Taller.Facturacion.Productos.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class ProductosController : Controller
    {
        private readonly IProductoService _productoService;
        public ProductosController(IProductoService productoService) {
            _productoService = productoService;
        }

        // GET: api/values
        [HttpGet]
        public ActionResult<IEnumerable<Producto>> Get()
        {
            return Ok(this._productoService.FindAll());
        }

        [HttpGet("/with-categories")]
        public ActionResult<IEnumerable<ProductoDto>> FindProductsWithCagegory()
        {
            return Ok(this._productoService.FindProductsWithCagegory());
        }

        // GET: api/values
        //[HttpGet]
        //public IEnumerable<Producto> Get()
        //{
        //    return this._productoService.findAll();
        //}

        // GET api/values/5
        //[HttpGet("{id}")]
        //public Producto Get(int id)
        //{

        //    return this._productoService.findById(id);
        //}

        [HttpGet("{id}")]
        public ActionResult<Producto> Get(int id)
        {
            if (id == 0) {
                return NotFound();
            }

            return Ok(this._productoService.FindById(id));
        }

        // POST api/values
        [HttpPost]
        public ActionResult<Producto> Post([FromBody] Producto producto)
        {
            //if (producto.Nombre.Length < 3) {
            //    return BadRequest("El producto debe tener al menos 3 caracteres");
            //}

            //if (!this.ModelState.IsValid) {
            //    return BadRequest(this.ModelState.ToArray());
            //}

            //this._productoService.Save(producto);
            //return Ok(producto);


            var response = new BaseResponse<Producto>();

            if (!this.ModelState.IsValid)
            {
                response.Errores = this.ModelState.ToArray();
                return BadRequest(response);
            }

            //try
            //{
                response.Code = (int)HttpStatusCode.OK;
                this._productoService.Save(producto);

                response.Data = producto;
            //}
            //catch (Exception ex)
            //{
            //    response.Errores = null;
            //    response.Code = (int)HttpStatusCode.BadRequest;
            //}

            return Ok(response);

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult<Producto> Put(int id, [FromBody] Producto producto)
        {
            this._productoService.Update(producto);
            return Ok(producto);
        }

        // PATCH api/values/5
        [HttpPatch("{id}")]
        public void Patch(int id, [FromBody] Producto producto)
        {
           
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            this._productoService.Delete(id);
            return Ok();
       }

        //[HttpGet("{id}/validar-stock-venta")]
        //public ActionResult validarStockVenta(int id, [FromQuery] int cantidad)
        //{
        //    var resultado = this._productoService.ValidarStockVenta(id, cantidad);
        //    return Ok(resultado);
        //}

        [HttpPost("/validar-stock-venta")]
        public ActionResult validarStockVenta([FromBody] IEnumerable<ProductoValidarStockDto> productosValidar)
        {
            var resultado = this._productoService.ValidarStockVenta(productosValidar);
            return Ok(resultado);
        }


    }
}
