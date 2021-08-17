using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Taller.Facturacion.Ventas.Domain.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Taller.Facturacion.Ventas.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class VentasController : Controller
    {
        // GET: api/values
        [HttpGet]
        public IEnumerable<Venta> Get()
        {

            var resultado = new List<Venta>();

            var venta1  =new Venta { Id = 1, ClienteId = 1, Direccion = "", Fecha = DateTime.Now, Monto = 450, Numero = 1 };
            venta1.Detalle = new List<VentaDetalle> { new VentaDetalle {Id=1, ProductoId=1, Cantidad=4, Precio=40, Importe=160 }};

            resultado.Add(venta1);

            return resultado; ;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
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
