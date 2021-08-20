using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Taller.Facturacion.Ventas.Application.Services.Contracts;
using Taller.Facturacion.Ventas.Domain.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Taller.Facturacion.Ventas.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class VentasController : Controller
    {
        private readonly IVentaService _ventaService;

        public VentasController(IVentaService ventaService) {
            _ventaService = ventaService;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<Venta> Get()
        {
            return _ventaService.FindAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public async void Post([FromBody] Venta venta)
        {
            //LLamar a Microservicio de Productos
            // Obtener Producto
            // Validar stock

            await _ventaService.Save(venta);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
