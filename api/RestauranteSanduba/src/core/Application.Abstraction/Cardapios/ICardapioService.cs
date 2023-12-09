using RestauranteSanduba.Core.Application.Abstraction.Cardapios.Request;
using RestauranteSanduba.Core.Application.Abstraction.Cardapios.Response;
using System.Collections.Generic;

namespace RestauranteSanduba.Core.Application.Abstraction.Cardapios
{
    public interface ICardapioService
    {
        public CadastroProdutoResponse CadastrarProduto(CadastroProdutoRequest request);
        public ConsultaProdutoResponse InativarProduto(AtualizaProdutoRequest request);
        public ConsultaProdutoResponse AtualizaPrecoProduto(AtualizaProdutoRequest request);
        public ConsultaProdutoResponse ConsultarProduto(ConsultaProdutoRequest request);
        public List<ConsultaProdutoResponse> ConsultarProdutosAtivos();
        public List<ConsultaProdutoResponse> ConsultarProdutos(List<ConsultaProdutoRequest> id);
    }
}
