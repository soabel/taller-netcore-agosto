using System;
namespace Taller.Facturacion.Productos.Infraestructure.Core.Exceptions
{
    public class BaseCustomException:Exception
    {
        public int StatusCode { get; set; }
        public BaseCustomException(string message) : base(message)
        { }

    }
}
