using RestauranteSanduba.Core.Application.Clientes.Abstractions.Request;
using RestauranteSanduba.Core.Application.Clientes.Abstractions.Response;

namespace RestauranteSanduba.Core.Application.Clientes.Abstractions
{
    public interface IClienteService
    {
        public CadastroClienteResponse CadastrarCliente(CadastroClienteRequest request);
        public ConsultaClienteResponse ConsultarCliente(ConsultaClienteRequest request);
        public ConsultaPedidosClienteResponse ConsultaPedidosCliente(ConsultaClienteRequest request);
    }
}
