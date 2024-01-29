using RestauranteSanduba.Core.Application.Abstraction.Clientes;
using RestauranteSanduba.Core.Application.Abstraction.Clientes.ResponseModel;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RestauranteSanduba.Adapter.ApiAdapter.Clientes
{
    public sealed class ClienteApiPresenter : ClientePresenter<string>
    {
        private string SerializeToJsonString(object obj)
        {
            if (obj is null) return string.Empty;

            try
            {
                return JsonSerializer.Serialize(obj);
            }
            catch
            {
                throw;
            }
        }

        public override string Present(CadastroClienteResponse responseModel)
        {
            return SerializeToJsonString(responseModel);
        }

        public override string Present(ConsultaClienteResponse responseModel)
        {
            return SerializeToJsonString(responseModel);
        }

        public override string Present(ConsultaPedidosClienteResponse responseModel)
        {
            return SerializeToJsonString(responseModel);
        }

        public override string Present(List<ConsultaClienteResponse> responseModel)
        {
            return SerializeToJsonString(responseModel);
        }
    }
}
