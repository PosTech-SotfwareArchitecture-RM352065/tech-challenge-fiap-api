using RestauranteSanduba.Core.Application.Abstraction.Clientes;
using RestauranteSanduba.Core.Application.Abstraction.Clientes.RequestModel;
using RestauranteSanduba.Core.Application.Abstraction.Clientes.ResponseModel;
using RestauranteSanduba.Core.Application.Abstraction.Pedidos;
using RestauranteSanduba.Core.Domain.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;


namespace RestauranteSanduba.Core.Application.Clientes
{
    public class ClienteInteractor : IClienteInteractor
    {
        private readonly IClientePersistenceGateway _clienteRepository;
        private readonly IPedidoPersistenceGateway _pedidoRepository;

        public ClienteInteractor(IClientePersistenceGateway clienteRepository, IPedidoPersistenceGateway pedidoRepository)
        {
            _clienteRepository = clienteRepository;
            _pedidoRepository = pedidoRepository;
        }

        public CadastroClienteResponse CadastrarCliente(CadastroClienteRequest request)
        {
            var cliente = ClienteIdentificado.CriarCliente(Guid.NewGuid(), request.CPF, request.Nome, request.Email);
            _clienteRepository.CadastrarCliente(cliente);

            return new CadastroClienteResponse() { Id = cliente.Id };
        }

        public ConsultaPedidosClienteResponse ConsultaPedidosCliente(ConsultaClienteRequest request)
        {
            var cliente = _clienteRepository.ConsultarCliente(new CPF(request.CPF));
            var pedidos = _pedidoRepository.ConsultaPedidosPorCliente(cliente.Id);

            return new ConsultaPedidosClienteResponse() { Pedidos = pedidos.Select(p => p.Id).ToList() };
        }

        public ConsultaClienteResponse ConsultarCliente(ConsultaClienteRequest request)
        {
            var cliente = _clienteRepository.ConsultarCliente(new CPF(request.CPF));

            return new ConsultaClienteResponse()
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                Email = cliente.Email,
                Cpf = cliente.CPF.ToString(),
            };
        }

        public List<ConsultaClienteResponse> ConsultarClientes()
        {
            var clientes = _clienteRepository.ConsultarClientes();

            return clientes.Select(cliente => new ConsultaClienteResponse()
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                Email = cliente.Email,
                Cpf = cliente.CPF.ToString()
            }).ToList();
        }
    }
}
