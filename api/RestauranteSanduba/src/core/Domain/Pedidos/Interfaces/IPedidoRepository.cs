using RestauranteSanduba.Core.Domain.Cardapios;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestauranteSanduba.Core.Domain.Pedidos.Interfaces
{
    public interface IPedidoRepository
    {
        public Pedido ObtemPedido(int numeroPedido);
        public List<Pedido> ObtemPedidosPorCliente(Guid clienteId);
        public void SalvarPedido(Pedido pedido);

        public void AtualizaPedido(Pedido pedido);
    }
}
