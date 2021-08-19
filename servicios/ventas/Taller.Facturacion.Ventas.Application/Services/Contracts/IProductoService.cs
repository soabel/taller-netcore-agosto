using System;
using System.Threading.Tasks;

namespace Taller.Facturacion.Ventas.Application.Services.Contracts
{
    public interface IProductoService
    {
        Task<bool> ValidarStockVenta(int productoId, int cantidad);
    }
}
