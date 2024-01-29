using RestauranteSanduba.Core.Application.Abstraction.Pedidos;
using RestauranteSanduba.Core.Application.Abstraction.Pedidos.ResponseModel;
using System.Text.Json;

namespace RestauranteSanduba.Adapter.ApiAdapter.Pedidos
{
    public sealed class PedidoApiPresenter : PedidoPresenter<string>
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

        public override string Present(CriacaoPedidoResponse responseModel)
        {
            return SerializeToJsonString(responseModel);
        }

        public override string Present(ConsultaPedidoResponse responseModel)
        {
            return SerializeToJsonString(responseModel);
        }
    }
}
