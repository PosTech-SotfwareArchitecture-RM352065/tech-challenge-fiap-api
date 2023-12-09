using RestauranteSanduba.Core.Domain.Pedidos;
using System;
using System.Collections.Generic;

namespace RestauranteSanduba.Core.Application.Abstraction.Pedidos
{
    public interface IPedidoRepository
    {
        public Pedido ConsultaPedido(int numeroPedido);
        public List<Pedido> ConsultaPedidosPorCliente(Guid clienteId);
        public void CadastraPedido(Pedido pedido);
        public int ConsultaProximoNumeroPedido();
    }
}
