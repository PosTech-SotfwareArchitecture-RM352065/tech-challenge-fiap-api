using System;
using System.Collections.Generic;

namespace RestauranteSanduba.Core.Domain.Cardapios.Abstractions
{
    public interface ICardapioRepository
    {
        public void CriaProduto(Produto produto);
        public void RemoveProduto(Produto produto);
        public void AtualizaProduto(Produto produto);
        public Produto ObtemProduto(Guid id);
        public List<Produto> ObtemProdutos();
    }
}
