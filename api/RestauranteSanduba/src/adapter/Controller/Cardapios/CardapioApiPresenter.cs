using RestauranteSanduba.Core.Application.Abstraction.Cardapios;
using RestauranteSanduba.Core.Application.Abstraction.Cardapios.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RestauranteSanduba.Adapter.ApiAdapter.Cardapios
{
    public sealed class CardapioApiPresenter : CardapioPresenter<string>
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

        public override string Present(CadastroProdutoResponse responseModel)
        {
            return SerializeToJsonString(responseModel);
        }

        public override string Present(ConsultaProdutoResponse responseModel)
        {
            return SerializeToJsonString(responseModel);
        }

        public override string Present(List<ConsultaProdutoResponse> responseModel)
        {
            return SerializeToJsonString(responseModel);
        }
    }
}
