using RestauranteSanduba.Core.Application.Abstraction.Carrinhos.ResponseModel;
using System.Collections.Generic;

namespace RestauranteSanduba.Core.Application.Abstraction.Carrinhos
{
    public abstract class CarrinhoPresenter<T>
    {
        public abstract T Present(CadastroCarrinhoResponseModel responseModel);
        public abstract T Present(ConsultaCarrinhoResponseModel responseModel);
        public abstract T Present(List<ConsultaCarrinhoResponseModel> responseModel);
    }
}
