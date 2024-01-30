using RestauranteSanduba.Core.Domain.Pedidos;
using System;
using System.Collections.Generic;

namespace RestauranteSanduba.Core.Application.Abstraction.Pedidos
{
    public interface IPedidoPersistenceGateway
    {
        public Pedido ConsultaPedido(Guid pedidoId);
        public List<Pedido> ConsultaPedidoPorStatus(string status);
        public List<Pedido> ConsultaPedidosPorCliente(Guid clienteId);
        public void CadastraPedido(Pedido pedido);
        public int ConsultaProximoNumeroPedido();
    }
}
