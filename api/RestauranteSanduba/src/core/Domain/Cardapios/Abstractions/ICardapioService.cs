using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteSanduba.Core.Domain.Cardapios.Abstractions
{
    public interface ICardapioService
    {
        public void CriaProduto(Produto produto);
        public void RemoveProduto(Produto produto);
        public void AtualizaPrecoProduto(Guid id, double novoPreco);
        public Produto ObtemProduto(Guid id);
        public List<Produto> ObtemProdutos();
    }
}
