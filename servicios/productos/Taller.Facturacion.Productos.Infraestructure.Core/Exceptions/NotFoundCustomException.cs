using System;
using System.Net;

namespace Taller.Facturacion.Productos.Infraestructure.Core.Exceptions
{
    public class NotFoundCustomException: BaseCustomException
    {
        public NotFoundCustomException(string value): base($"El elemento ${value} no existe")
        {
            this.StatusCode = (int)HttpStatusCode.NotFound;
        }
    }
}
