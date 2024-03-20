using RestauranteSanduba.Core.Application.Abstraction.Carrinhos.RequestModel;
using RestauranteSanduba.Core.Application.Abstraction.Carrinhos.ResponseModel;
using System.Collections.Generic;

namespace RestauranteSanduba.Core.Application.Abstraction.Carrinhos
{
    public interface ICarrinhoInteractor
    {
        public CadastroCarrinhoResponse CadastrarProduto(CadastroCarrinhoRequest requestModel);
        public ConsultaCarrinhoResponse RemoverProduto(RemoveCarrinhoRequest requestModel);
        public List<ConsultaCarrinhoResponse> ConsultarProdutos(ConsultaCarrinhoRequest requestModel);
    }
}
