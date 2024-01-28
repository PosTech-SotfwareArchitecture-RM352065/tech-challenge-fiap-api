using RestauranteSanduba.Core.Domain.Cardapios;
using System;
using System.Collections.Generic;

namespace RestauranteSanduba.Core.Application.Abstraction.Cardapios
{
    public interface ICardapioPersistenceGateway 
    {
        public void CadastrarProduto(Produto produto);
        public void InativarProduto(Produto produto);
        public Produto ConsultarProduto(Guid id);
        public Produto ConsultarProduto(string nome);
        public List<Produto> ConsultarProdutos(List<Guid> ids);
        public List<Produto> ConsultarProdutosAtivos();
    }
}
