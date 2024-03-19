using RestauranteSanduba.Core.Application.Abstraction.Pedidos.RequestModel;
using RestauranteSanduba.Core.Application.Abstraction.Pedidos.ResponseModel;
using System.Collections.Generic;

namespace RestauranteSanduba.Core.Application.Abstraction.Pedidos
{
    public interface IPedidoInteractor
    {
        public List<ConsultaPedidoResponse> OntemPedido(ConsultaPedidoPorStatus requestModel);
        public ConsultaPedidoResponse ObtemPedido(ConsultaPedidoRequest requestModel);
        public List<ConsultaPedidoResponse> ObtemPedidoPorCliente(ConsultaPedidoPorClienteRequest requestModel);
        public CriacaoPedidoResponse CriaPedido(CriacaoPedidoRequestModel requestModel);
        public AtualizaPedidoResponse PedidoEmPreparacao(AtualizaPedidoRequest requestModel);
        public AtualizaPedidoResponse PedidoFinalizado(AtualizaPedidoRequest requestModel);
    }
}
