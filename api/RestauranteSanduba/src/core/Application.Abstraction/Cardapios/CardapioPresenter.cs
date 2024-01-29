using System;
using System.Collections.Generic;
using RestauranteSanduba.Core.Application.Abstraction.Cardapios.ResponseModel;

namespace RestauranteSanduba.Core.Application.Abstraction.Cardapios
{
    public abstract class CardapioPresenter<T>
    {
        public abstract T Present(CadastroProdutoResponse responseModel);
        public abstract T Present(ConsultaProdutoResponse responseModel);
        public abstract T Present(List<ConsultaProdutoResponse> responseModel);
    }
}
