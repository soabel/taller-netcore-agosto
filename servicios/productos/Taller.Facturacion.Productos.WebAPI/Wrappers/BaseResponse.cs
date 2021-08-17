using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Taller.Facturacion.Productos.WebAPI.Wrappers
{
    public class BaseResponse<T>
    {
        public T Data { get; set; }
        public int Code { get; set; }
        public IEnumerable<KeyValuePair<string, ModelStateEntry>> Errores { get; set; }
        public string Message { get; set; }

        //IEnumerable<KeyValuePair<string, Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateEntry>>.

    }
}
