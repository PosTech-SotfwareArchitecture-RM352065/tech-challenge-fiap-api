using System;
using System.Collections.Generic;

namespace RestauranteSanduba.Core.Domain.Pedidos.Interfaces
{
    public interface IPedidoService
    {
        public Pedido ObtemPedido(int numeroPedido);
        public List<Pedido> ObtemPedidoPorCliente(Guid clienteId);
        public void CriaPedido(Pedido pedido);
        public void PedidoEmPreparacao(Pedido pedido);
        public void PedidoFinalizado(Pedido pedido);
    }
}
