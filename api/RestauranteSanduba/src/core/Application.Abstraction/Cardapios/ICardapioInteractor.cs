using RestauranteSanduba.Core.Application.Abstraction.Cardapios.RequestModel;
using RestauranteSanduba.Core.Application.Abstraction.Cardapios.ResponseModel;
using System.Collections.Generic;

namespace RestauranteSanduba.Core.Application.Abstraction.Cardapios
{
    public interface ICardapioInteractor
    {
        public CadastroProdutoResponse CadastrarProduto(CadastroProdutoRequest requestModel);
        public ConsultaProdutoResponse InativarProduto(InativarProdutoRequest requestModel);
        public ConsultaProdutoResponse AtualizaProduto(AtualizaProdutoRequest requestModel);
        public ConsultaProdutoResponse ConsultarProduto(ConsultaProdutoRequest requestModel);
        public List<ConsultaProdutoResponse> ConsultarProdutosAtivos();
        public List<ConsultaProdutoResponse> ConsultarProdutos(List<ConsultaProdutoRequest> requestModel);
    }
}
