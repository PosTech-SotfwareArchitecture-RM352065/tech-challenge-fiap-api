using RestauranteSanduba.Core.Application.Abstraction.Cardapios.RequestModel;
using RestauranteSanduba.Core.Application.Abstraction.Cardapios.ResponseModel;
using System.Collections.Generic;

namespace RestauranteSanduba.Core.Application.Abstraction.Cardapios
{
    public interface ICardapioInteractor
    {
        public CadastroProdutoResponse CadastrarProduto(CadastroProdutoRequest request);
        public ConsultaProdutoResponse InativarProduto(InativarProdutoRequest request);
        public ConsultaProdutoResponse AtualizaProduto(AtualizaProdutoRequest request);
        public ConsultaProdutoResponse ConsultarProduto(ConsultaProdutoRequest request);
        public List<ConsultaProdutoResponse> ConsultarProdutosAtivos();
        public List<ConsultaProdutoResponse> ConsultarProdutos(List<ConsultaProdutoRequest> id);
    }
}
