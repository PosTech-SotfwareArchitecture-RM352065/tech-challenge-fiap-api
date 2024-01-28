using RestauranteSanduba.Core.Application.Abstraction.Cardapios;
using RestauranteSanduba.Core.Application.Abstraction.Clientes;
using RestauranteSanduba.Core.Application.Abstraction.Pedidos;
using RestauranteSanduba.Core.Application.Abstraction.Pedidos.RequestModel;
using RestauranteSanduba.Core.Application.Abstraction.Pedidos.ResponseModel;
using RestauranteSanduba.Core.Domain.Pedidos;
using System;
using System.Collections.Generic;

namespace RestauranteSanduba.Core.Application.Pedidos
{
    public sealed class PedidoService : IPedidoInteractor
    {
        private readonly IPedidoPersistenceGateway _pedidoRepository;
        private readonly IClientePersistenceGateway _clienteRepository;
        private readonly ICardapioPersistenceGateway _cardapioRepository;

        public PedidoService(IPedidoPersistenceGateway pedidoRepository, IClientePersistenceGateway clienteRepository, ICardapioPersistenceGateway cardapioRepository)
        {
            _pedidoRepository = pedidoRepository;
            _clienteRepository = clienteRepository;
            _cardapioRepository = cardapioRepository;
        }

        public CriacaoPedidoResponse CriaPedido(CriacaoPedidoRequest request)
        {
            var cliente = _clienteRepository.ConsultarCliente(request.ClienteId);
            var numeroPedido = _pedidoRepository.ConsultaProximoNumeroPedido();
            var produtos = _cardapioRepository.ConsultarProdutos(request.Itens);

            var pedido = Pedido.CriarPedido(Guid.NewGuid(), cliente, numeroPedido);
            pedido.AdicionaProdutos(produtos);

            _pedidoRepository.CadastraPedido(pedido);

            return new CriacaoPedidoResponse(numeroPedido, pedido.ObtemTotal());
        }

        public Pedido ObtemPedido(int numeroPedido)
        {
            return _pedidoRepository.ConsultaPedido(numeroPedido);
        }

        public List<Pedido> ObtemPedidoPorCliente(Guid clienteId)
        {
            return _pedidoRepository.ConsultaPedidosPorCliente(clienteId);
        }

        public void PedidoEmPreparacao(Pedido pedido)
        {
            throw new NotImplementedException();
        }

        public void PedidoFinalizado(Pedido pedido)
        {
            throw new NotImplementedException();
        }
    }
}
