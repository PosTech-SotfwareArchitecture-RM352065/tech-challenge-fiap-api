using RestauranteSanduba.Core.Domain.Common.Assertions;
using RestauranteSanduba.Core.Domain.Common.Types;
using System;
using System.Collections.Generic;

namespace RestauranteSanduba.Core.Domain.Cardapios
{
    public sealed class Cardapio : AggregateRoot
    {
        private readonly List<Produto> _produtos = new();
        public IReadOnlyCollection<Produto> Produtos
        {
            get { return _produtos; }
        }

        private Cardapio(Guid id) : base(id) { }

        public override void ValidateEntity()
        {
            AssertionConcern.AssertArgumentNotEmpty(_produtos, "Cardápio não pode estar vazio");
        }
    }
}
