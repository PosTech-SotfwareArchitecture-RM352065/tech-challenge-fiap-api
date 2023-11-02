using RestauranteSanduba.Core.Application.Cardapios.Abstractions.Request;
using RestauranteSanduba.Core.Application.Cardapios.Abstractions.Response;
using RestauranteSanduba.Core.Domain.Cardapios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteSanduba.Core.Application.Cardapios.Abstractions
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
