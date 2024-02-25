using RestauranteSanduba.Core.Application.Abstraction.Pedidos.ResponseModel;

namespace RestauranteSanduba.Core.Application.Abstraction.Pedidos
{
    public abstract class PedidoPresenter<T>
    {
        public abstract T Present(CriacaoPedidoResponse responseModel);
        public abstract T Present(ConsultaPedidoResponse responseModel);
    }
}
