using RestauranteSanduba.Core.Application.Abstraction.Clientes.Request;
using RestauranteSanduba.Core.Application.Abstraction.Clientes.Response;

namespace RestauranteSanduba.Core.Application.Abstraction.Clientes
{
    public interface IClienteService
    {
        public CadastroClienteResponse CadastrarCliente(CadastroClienteRequest request);
        public ConsultaClienteResponse ConsultarCliente(ConsultaClienteRequest request);
        public ConsultaPedidosClienteResponse ConsultaPedidosCliente(ConsultaClienteRequest request);
    }
}
