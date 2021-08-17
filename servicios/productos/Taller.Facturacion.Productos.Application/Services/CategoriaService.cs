using System;
using System.Collections.Generic;
using System.Linq;
using Taller.Facturacion.Productos.Application.Services.Contracts;
using Taller.Facturacion.Productos.Domain.Entities;
using Taller.Facturacion.Productos.Domain.Repositories;
using Taller.Facturacion.Productos.Infraestructure.Core.Exceptions;

namespace Taller.Facturacion.Productos.Application.Services
{
    public class CategoriaService: ICategoriaService
    {
        //private readonly ICategoriaRepository _categoriaRepository;
        private readonly IGenericRepository<Categoria> _categoriaRepository;
        public CategoriaService(IGenericRepository<Categoria> categoriaRepository)
        {
            this._categoriaRepository = categoriaRepository;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Categoria> FindAll()
        {
            //return this._categoriaRepository.FindAll(null, "Productos");

            return this._categoriaRepository.FindAll(c=> c.Nombre.Contains("Electro") , "Productos");
        }

        public Categoria FindById(int id)
        {
            var result = this._categoriaRepository.FindById(id);
            if (result == null) {
                throw new NotFoundCustomException(id.ToString());
            }
            return result;
        }

        public void Save(Categoria product)
        {
            throw new NotImplementedException();
        }

        public void Update(Categoria product)
        {
            throw new NotImplementedException();
        }
    }
}
