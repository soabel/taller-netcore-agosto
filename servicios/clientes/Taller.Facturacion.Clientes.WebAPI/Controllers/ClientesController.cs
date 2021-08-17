using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Taller.Facturacion.Clientes.Domain.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Taller.Facturacion.Clientes.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class ClientesController : Controller
    {
        // GET: api/values
        [HttpGet]
        public IEnumerable<Cliente> Get()
        {
            var resultado = new List<Cliente>() {
                new Cliente() { Id=1, Nombre="Alfredo Benaute", Direccion="Las liras #1988", Email="alfredo@gmail.com", NumeroIdentidad="12345671" },
                new Cliente() { Id=2, Nombre="Carlos Cardenas", Direccion="Los Cocos #200", Email="carlos@gmail.com", NumeroIdentidad="88888888" } };


            return resultado;
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
