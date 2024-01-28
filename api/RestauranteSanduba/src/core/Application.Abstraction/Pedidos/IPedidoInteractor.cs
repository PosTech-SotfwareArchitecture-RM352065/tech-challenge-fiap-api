using RestauranteSanduba.Core.Application.Abstraction.Pedidos.RequestModel;
using RestauranteSanduba.Core.Application.Abstraction.Pedidos.ResponseModel;
using RestauranteSanduba.Core.Domain.Pedidos;
using System;
using System.Collections.Generic;

namespace RestauranteSanduba.Core.Application.Abstraction.Pedidos
{
    public interface IPedidoInteractor
    {
        public Pedido ObtemPedido(int numeroPedido);
        public List<Pedido> ObtemPedidoPorCliente(Guid clienteId);
        public CriacaoPedidoResponse CriaPedido(CriacaoPedidoRequest request);
        public void PedidoEmPreparacao(Pedido pedido);
        public void PedidoFinalizado(Pedido pedido);
    }
}
