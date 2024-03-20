using RestauranteSanduba.Core.Application.Abstraction.Carrinhos;
using RestauranteSanduba.Core.Application.Abstraction.Carrinhos.ResponseModel;
using System.Collections.Generic;
using System.Text.Json;

namespace RestauranteSanduba.Adapter.ApiAdapter.Cardapios
{
    public sealed class CarrinhoApiPresenter : CarrinhoPresenter<string>
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

        public override string Present(CadastroCarrinhoResponse responseModel)
        {
            return SerializeToJsonString(responseModel);
        }

        public override string Present(ConsultaCarrinhoResponse responseModel)
        {
            return SerializeToJsonString(responseModel);
        }

        public override string Present(List<ConsultaCarrinhoResponse> responseModel)
        {
            return SerializeToJsonString(responseModel);
        }
    }
}
