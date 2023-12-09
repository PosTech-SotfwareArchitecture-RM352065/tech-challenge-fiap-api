using RestauranteSanduba.Core.Application.Abstraction.Pedidos.Request;
using RestauranteSanduba.Core.Application.Abstraction.Pedidos.Response;
using RestauranteSanduba.Core.Domain.Pedidos;
using System;
using System.Collections.Generic;

namespace RestauranteSanduba.Core.Application.Abstraction.Pedidos
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
