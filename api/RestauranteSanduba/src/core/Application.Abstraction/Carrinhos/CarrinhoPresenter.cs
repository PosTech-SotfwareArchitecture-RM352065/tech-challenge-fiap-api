using RestauranteSanduba.Core.Application.Abstraction.Carrinhos.ResponseModel;
using System.Collections.Generic;

namespace RestauranteSanduba.Core.Application.Abstraction.Carrinhos
{
    public abstract class CarrinhoPresenter<T>
    {
        public abstract T Present(CadastroCarrinhoResponse responseModel);
        public abstract T Present(ConsultaCarrinhoResponse responseModel);
        public abstract T Present(List<ConsultaCarrinhoResponse> responseModel);
    }
}
