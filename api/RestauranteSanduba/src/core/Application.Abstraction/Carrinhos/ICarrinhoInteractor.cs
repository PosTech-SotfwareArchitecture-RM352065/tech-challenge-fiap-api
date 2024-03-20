using RestauranteSanduba.Core.Application.Abstraction.Carrinhos.RequestModel;
using RestauranteSanduba.Core.Application.Abstraction.Carrinhos.ResponseModel;
using System.Collections.Generic;

namespace RestauranteSanduba.Core.Application.Abstraction.Carrinhos
{
    public interface ICarrinhoInteractor
    {
        public CadastroCarrinhoResponseModel CadastrarProduto(CadastroCarrinhoRequestModel requestModel);
        public ConsultaCarrinhoResponseModel RemoverProduto(RemoveCarrinhoRequestModel requestModel);
        public List<ConsultaCarrinhoResponseModel> ConsultarProdutos(ConsultaCarrinhoRequest requestModel);
    }
}
