using System;
using System.Net.Http;
using System.Threading.Tasks;
using Taller.Facturacion.Ventas.Application.Services.Contracts;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Taller.Facturacion.Ventas.Application.Dtos;
using System.Collections.Generic;
using System.Text;

namespace Taller.Facturacion.Ventas.Application.Services
{
    public class ProductoService : IProductoService
    {
        private IHttpClientFactory _httpClientFactory;

        public ProductoService( IHttpClientFactory httpClientFactory) {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<bool> ValidarStockVenta(IEnumerable<ProductoValidarStockDto> productosValidar)
        {
            try
            {
                HttpClient httpClient = _httpClientFactory.CreateClient();
                httpClient.BaseAddress = new Uri("https://localhost:6002");

                var content = JsonConvert.SerializeObject(productosValidar);
                var response = await httpClient.PostAsync($"/api/productos/validar-stock-venta",
                    new StringContent(content, Encoding.UTF8, "application/json"));
                string responseString = await response.Content.ReadAsStringAsync();

                //var jObject = JObject.Parse(responseString);
                //var jToken = jObject.GetValue("data");
                //var result = (bool)jToken.ToObject(typeof(bool));

                return bool.Parse(responseString);
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }
    }
}
