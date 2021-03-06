using System;
using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Taller.Facturacion.Productos.Application.Services.Contracts;
using Taller.Facturacion.Productos.Domain.Entities;
using Taller.Facturacion.Productos.WebAPI.Wrappers;

namespace Taller.Facturacion.Productos.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class CategoriasController: Controller
    {
        private readonly ICategoriaService _categoriaService;
        private readonly ILogger<CategoriasController> _logger;
        public CategoriasController(ICategoriaService categoriaService, ILogger<CategoriasController> logger)
        {
            this._categoriaService = categoriaService;
            this._logger = logger;
        }

        [HttpGet]
        public ActionResult<BaseResponse<IEnumerable<Categoria>>>  Get() {

            this._logger.LogTrace("Call Categorias-Get");

            var response=new BaseResponse<IEnumerable<Categoria>>();

            try
            {
                response.Code = (int)HttpStatusCode.OK;
                response.Data = this._categoriaService.FindAll();
            }
            catch (Exception ex)
            {
                response.Errores = null;
                response.Code= (int)HttpStatusCode.BadRequest;
            }
           
            return Ok(response);
        }

        
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Categoria>> GetById(int id)
        {
            return Ok(this._categoriaService.FindById(id));
        }


    }
}
