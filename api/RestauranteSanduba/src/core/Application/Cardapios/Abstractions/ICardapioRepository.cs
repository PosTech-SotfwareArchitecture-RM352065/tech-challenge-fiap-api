using RestauranteSanduba.Core.Domain.Cardapios;
using System;
using System.Collections.Generic;

namespace RestauranteSanduba.Core.Application.Cardapios.Abstractions
{
    public interface ICardapioRepository
    {
        public void CadastrarProduto(Produto produto);
        public void InativarProduto(Produto produto);
        public Produto ConsultarProduto(Guid id);
        public List<Produto> ConsultarProdutos(List<Guid> ids);
        public List<Produto> ConsultarProdutosAtivos();
    }
}
