using RestauranteSanduba.Core.Application.Pedidos.Request;
using RestauranteSanduba.Core.Application.Pedidos.Response;
using RestauranteSanduba.Core.Domain.Pedidos;
using System;
using System.Collections.Generic;

namespace RestauranteSanduba.Core.Application.Pedidos.Abstractions
{
    public interface IPedidoService
    {
        public Pedido ObtemPedido(int numeroPedido);
        public List<Pedido> ObtemPedidoPorCliente(Guid clienteId);
        public CriacaoPedidoResponse CriaPedido(CriacaoPedidoRequest request);
        public void PedidoEmPreparacao(Pedido pedido);
        public void PedidoFinalizado(Pedido pedido);
    }
}
