using RestauranteSanduba.Core.Application.Abstraction.Clientes.RequestModel;
using RestauranteSanduba.Core.Application.Abstraction.Clientes.ResponseModel;

namespace RestauranteSanduba.Core.Application.Abstraction.Clientes
{
    public interface IClienteInteractor
    {
        public CadastroClienteResponse CadastrarCliente(CadastroClienteRequest request);
        public ConsultaClienteResponse ConsultarCliente(ConsultaClienteRequest request);
        public ConsultaPedidosClienteResponse ConsultaPedidosCliente(ConsultaClienteRequest request);
    }
}
