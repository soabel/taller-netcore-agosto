using System;
using Microsoft.AspNetCore.Mvc;

namespace Taller.Facturacion.Productos.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class CategoriasController: Controller
    {
        public CategoriasController()
        {
        }

        [HttpGet]
        public string Get() {

            return "hello categoria";
        }

        
    }
}
