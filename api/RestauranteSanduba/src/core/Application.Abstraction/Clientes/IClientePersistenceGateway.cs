using RestauranteSanduba.Core.Domain.Clientes;
using RestauranteSanduba.Core.Domain.Clientes.Abstractions;
using System;
using System.Collections.Generic;

namespace RestauranteSanduba.Core.Application.Abstraction.Clientes
{
    public interface IClientePersistenceGateway
    {
        public Cliente ConsultarCliente(Guid clienteId);
        public Cliente ConsultarCliente(CPF numeroDocumento);
        public List<Cliente> ConsultarClientes();
        public Guid CadastrarCliente(Cliente cliente);
    }
}
