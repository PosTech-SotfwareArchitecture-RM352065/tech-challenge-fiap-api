using RestauranteSanduba.Core.Application.Abstraction.Cardapios.RequestModel;
using RestauranteSanduba.Core.Application.Abstraction.Cardapios.ResponseModel;
using System.Collections.Generic;

namespace RestauranteSanduba.Core.Application.Abstraction.Cardapios
{
    public interface ICardapioInputport
    {
        public CadastroProdutoResponse CadastrarProduto(CadastroProdutoRequest request);
        public ConsultaProdutoResponse InativarProduto(AtualizaProdutoRequest request);
        public ConsultaProdutoResponse AtualizaPrecoProduto(AtualizaProdutoRequest request);
        public ConsultaProdutoResponse ConsultarProduto(ConsultaProdutoRequest request);
        public List<ConsultaProdutoResponse> ConsultarProdutosAtivos();
        public List<ConsultaProdutoResponse> ConsultarProdutos(List<ConsultaProdutoRequest> id);
    }
}
