using RestauranteSanduba.Core.Application.Abstraction.Pedidos;
using RestauranteSanduba.Core.Application.Abstraction.Pedidos.RequestModel;

namespace RestauranteSanduba.Adapter.ApiAdapter.Pedidos
{
    public sealed class PedidoApiController : PedidoController<string>
    {
        public PedidoApiController(IPedidoInteractor interactor, PedidoPresenter<string> presenter) : base(interactor, presenter) { }

        public override string CriaPedido(CriacaoPedidoRequest requestModel)
        {
            var responseModel = interactor.CriaPedido(requestModel);
            return presenter.Present(responseModel);
        }

        public override string ObtemPedido(ConsultaPedidoRequest requestModel)
        {
            var responseModel = interactor.ObtemPedido(requestModel);
            return presenter.Present(responseModel);
        }
    }
}
