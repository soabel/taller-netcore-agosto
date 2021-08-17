using System;
namespace Taller.Facturacion.Clientes.Domain.Entities
{
    public class Cliente
    {
        public int Id { get; set; }
        public string NumeroIdentidad { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
       
    }
}
