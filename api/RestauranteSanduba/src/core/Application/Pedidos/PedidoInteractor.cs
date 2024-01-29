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
    public sealed class PedidoInteractor : IPedidoInteractor
    {
        private readonly IPedidoPersistenceGateway pedidoPersistenceGateway;
        private readonly IClientePersistenceGateway clientePersistenceGateway;
        private readonly ICardapioPersistenceGateway cardapioPersistenceGateway;

        public PedidoInteractor(IPedidoPersistenceGateway pedidoPersistenceGateway, IClientePersistenceGateway clientePersistenceGateway, ICardapioPersistenceGateway cardapioPersistenceGateway)
        {
            this.pedidoPersistenceGateway = pedidoPersistenceGateway;
            this.clientePersistenceGateway = clientePersistenceGateway;
            this.cardapioPersistenceGateway = cardapioPersistenceGateway;
        }

        public CriacaoPedidoResponse CriaPedido(CriacaoPedidoRequest request)
        {
            var cliente = clientePersistenceGateway.ConsultarCliente(request.ClienteId);
            var numeroPedido = pedidoPersistenceGateway.ConsultaProximoNumeroPedido();
            var produtos = cardapioPersistenceGateway.ConsultarProdutos(request.Itens);

            var pedido = Pedido.CriarPedido(Guid.NewGuid(), cliente, numeroPedido);
            pedido.AdicionaProdutos(produtos);

            pedidoPersistenceGateway.CadastraPedido(pedido);

            return new CriacaoPedidoResponse(numeroPedido, pedido.ObtemTotal());
        }

        public ConsultaPedidoResponse ObtemPedido(ConsultaPedidoRequest request)
        {
            var pedido = pedidoPersistenceGateway.ConsultaPedido(request.id);

            return new ConsultaPedidoResponse(
                Id: pedido.Id,
                NumeroPedido: (int)pedido.NumeroPedido,
                Status: pedido.Status.ToString(),
                Total: pedido.ObtemTotal()
            );
        }

        public List<ConsultaPedidoResponse> ObtemPedidoPorCliente(ConsultaPedidoPorClienteRequest request)
        {
            var pedidos = pedidoPersistenceGateway.ConsultaPedidosPorCliente(request.ClienteId);
            var response = new List<ConsultaPedidoResponse>();

            foreach(var pedido in pedidos)
            {
                response.Add(
                    new ConsultaPedidoResponse(
                        Id: pedido.Id,
                        NumeroPedido: (int)pedido.NumeroPedido,
                        Status: pedido.Status.ToString(),
                        Total: pedido.ObtemTotal()
                    ));
            }

            return response;
        }

        public AtualizaPedidoResponse PedidoEmPreparacao(AtualizaPedidoRequest request)
        {
            throw new NotImplementedException();
        }

        public AtualizaPedidoResponse PedidoFinalizado(AtualizaPedidoRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
