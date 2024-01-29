using RestauranteSanduba.Core.Application.Abstraction.Clientes.RequestModel;

namespace RestauranteSanduba.Core.Application.Abstraction.Clientes
{
    public abstract class ClienteController<T>
    {
        protected readonly IClienteInteractor interactor;
        protected readonly ClientePresenter<T> presenter;

        protected ClienteController(IClienteInteractor interactor, ClientePresenter<T> presenter)
        {
            this.interactor = interactor;
            this.presenter = presenter;
        }

        public abstract T CadastrarCliente(CadastroClienteRequest requestModel);
        public abstract T ConsultarCliente(ConsultaClienteRequest requestModel);
        public abstract T ConsultarClientes();
        public abstract T ConsultaPedidosCliente(ConsultaClienteRequest requestModel);
    }
}
