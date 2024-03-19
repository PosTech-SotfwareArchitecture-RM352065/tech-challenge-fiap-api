using RestauranteSanduba.Core.Application.Abstraction.Clientes.RequestModel;
using RestauranteSanduba.Core.Application.Abstraction.Clientes.ResponseModel;
using System.Collections.Generic;

namespace RestauranteSanduba.Core.Application.Abstraction.Clientes
{
    public interface IClienteInteractor
    {
        public CadastroClienteResponse CadastrarCliente(CadastroClienteRequestModel request);
        public ConsultaClienteResponse ConsultarCliente(ConsultaClienteRequest request);
        public List<ConsultaClienteResponse> ConsultarClientes();
        public ConsultaPedidosClienteResponse ConsultaPedidosCliente(ConsultaClienteRequest request);
    }
}
