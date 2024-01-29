using RestauranteSanduba.Core.Application.Abstraction.Clientes;
using RestauranteSanduba.Core.Application.Abstraction.Clientes.RequestModel;

namespace RestauranteSanduba.Adapter.ApiAdapter.Clientes
{
    public sealed class ClienteApiController : ClienteController<string>
    {
        public ClienteApiController(IClienteInteractor interactor, ClientePresenter<string> presenter) : base(interactor, presenter) { }

        public override string CadastrarCliente(CadastroClienteRequest requestModel)
        {
            var responseModel = interactor.CadastrarCliente(requestModel);
            return presenter.Present(responseModel);
        }

        public override string ConsultaPedidosCliente(ConsultaClienteRequest requestModel)
        {
            var responseModel = interactor.ConsultaPedidosCliente(requestModel);
            return presenter.Present(responseModel);
        }

        public override string ConsultarCliente(ConsultaClienteRequest requestModel)
        {
            var responseModel = interactor.ConsultarCliente(requestModel);
            return presenter.Present(responseModel);
        }

        public override string ConsultarClientes()
        {
            var responseModel = interactor.ConsultarClientes();
            return presenter.Present(responseModel);
        }
    }
}
