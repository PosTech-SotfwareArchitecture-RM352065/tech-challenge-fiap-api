using RestauranteSanduba.Core.Application.Abstraction.Clientes.ResponseModel;
using System.Collections.Generic;

namespace RestauranteSanduba.Core.Application.Abstraction.Clientes
{
    public abstract class ClientePresenter<T>
    {
        public abstract T Present (CadastroClienteResponse responseModel);
        public abstract T Present (ConsultaClienteResponse responseModel);
        public abstract T Present(List<ConsultaClienteResponse> responseModel);
        public abstract T Present (ConsultaPedidosClienteResponse responseModel);
    }
}
