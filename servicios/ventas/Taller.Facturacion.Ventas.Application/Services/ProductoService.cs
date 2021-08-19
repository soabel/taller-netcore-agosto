using System;
using System.Net.Http;
using System.Threading.Tasks;
using Taller.Facturacion.Ventas.Application.Services.Contracts;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace Taller.Facturacion.Ventas.Application.Services
{
    public class ProductoService : IProductoService
    {
        private IHttpClientFactory _httpClientFactory;

        public ProductoService( IHttpClientFactory httpClientFactory) {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<bool> ValidarStockVenta(int productoId, int cantidad)
        {
            try
            {
              
                //https://localhost:6002/api/productos/1/validar-stock-venta?cantidad=6

                HttpClient httpClient = _httpClientFactory.CreateClient();
                httpClient.BaseAddress = new Uri("https://localhost:6002");

                var response = await httpClient.GetAsync($"/api/productos/{productoId}/validar-stock-venta?cantidad={cantidad}");
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
