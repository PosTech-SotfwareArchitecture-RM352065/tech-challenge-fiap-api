using RestauranteSanduba.Core.Domain.Clientes;
using RestauranteSanduba.Core.Domain.Clientes.Abstractions;
using System;

namespace RestauranteSanduba.Core.Application.Abstraction.Clientes
{
    public interface IClienteRepository
    {
        public Cliente ConsultarCliente(Guid clienteId);
        public Cliente ConsultarCliente(CPF numeroDocumento);
        public void CadastrarCliente(Cliente cliente);
    }
}
