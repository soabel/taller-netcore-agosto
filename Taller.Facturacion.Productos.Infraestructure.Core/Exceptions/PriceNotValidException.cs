using System;
using System.Net;

namespace Taller.Facturacion.Productos.Infraestructure.Core.Exceptions
{
    public class PriceNotValidException: BaseCustomException
    {
        public PriceNotValidException(string value) : base($"El precio ${value} no es valido. Debe ser mayor a CERO.")
        {
            this.StatusCode = 801;
        }
    }
}
