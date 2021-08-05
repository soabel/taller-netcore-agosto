﻿using System;
using System.Collections.Generic;
using Taller.Facturacion.Productos.Domain.Entities;

namespace Taller.Facturacion.Productos.Application.Services.Contracts
{
    public interface IProductoService
    {
        IEnumerable<Producto> FindAll();
        Producto FindById(int id);
        void Save(Producto product);
        void Update(Producto product);
    }
}
