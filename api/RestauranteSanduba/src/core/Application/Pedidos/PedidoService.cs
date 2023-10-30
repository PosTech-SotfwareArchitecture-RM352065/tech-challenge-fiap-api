using RestauranteSanduba.Core.Domain.Pedidos;
using RestauranteSanduba.Core.Domain.Pedidos.Interfaces;
using System;
using System.Collections.Generic;

namespace RestauranteSanduba.Core.Application.Pedidos
{
    public sealed class PedidoService : IPedidoService
    {
        private readonly IPedidoRepository _pedidoRepository;

        public void CriaPedido(Pedido pedido)
        {
            throw new NotImplementedException();
        }

        public Pedido ObtemPedido(int numeroPedido)
        {
            return _pedidoRepository.ObtemPedido(numeroPedido);
        }

        public List<Pedido> ObtemPedidoPorCliente(Guid clienteId)
        {
            return _pedidoRepository.ObtemPedidosPorCliente(clienteId);
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
