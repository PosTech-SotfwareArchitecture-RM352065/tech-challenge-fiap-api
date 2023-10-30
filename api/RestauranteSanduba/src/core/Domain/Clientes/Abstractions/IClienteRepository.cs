using System;

namespace RestauranteSanduba.Core.Domain.Clientes.Abstractions
{
    public interface IClienteRepository
    {
        public Cliente ObtemCliente(Guid codigoCliente);
        public Cliente ObtemCliente(CPF numeroDocumento);
        public void CriarCliente(Cliente cliente);
    }
}
