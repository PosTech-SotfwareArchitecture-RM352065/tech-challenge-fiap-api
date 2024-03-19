using RestauranteSanduba.Core.Application.Abstraction.Clientes;
using RestauranteSanduba.Core.Application.Abstraction.Pedidos.RequestModel;
using RestauranteSanduba.Core.Application.Abstraction.Pedidos.ResponseModel;

namespace RestauranteSanduba.Core.Application.Abstraction.Pedidos
{
    public abstract class PedidoController<T>
    {
        protected readonly IPedidoInteractor interactor;
        protected readonly PedidoPresenter<T> presenter;

        protected PedidoController(IPedidoInteractor interactor, PedidoPresenter<T> presenter)
        {
            this.interactor = interactor;
            this.presenter = presenter;
        }

        public abstract T CriaPedido(CriacaoPedidoRequestModel requestModel);
        public abstract T ObtemPedido(ConsultaPedidoRequest requestModel);
    }
}
