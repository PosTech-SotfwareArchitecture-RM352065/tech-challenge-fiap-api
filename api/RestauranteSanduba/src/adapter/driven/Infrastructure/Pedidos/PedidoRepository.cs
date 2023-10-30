using RestauranteSanduba.Core.Domain.Pedidos;
using RestauranteSanduba.Core.Domain.Pedidos.Interfaces;
using System;
using System.Collections.Generic;

namespace RestauranteSanduba.Adapter.Driven.Infrastructure.Pedidos
{
    public class PedidoRepository : IPedidoRepository
    {
        public void AtualizaPedido(Pedido pedido)
        {
            throw new NotImplementedException();
        }

        public Pedido ObtemPedido(int numeroPedido)
        {
            throw new NotImplementedException();
        }

        public List<Pedido> ObtemPedidosPorCliente(Guid clienteId)
        {
            throw new NotImplementedException();
        }

        public void SalvarPedido(Pedido pedido)
        {
            throw new NotImplementedException();
        }
    }
}
