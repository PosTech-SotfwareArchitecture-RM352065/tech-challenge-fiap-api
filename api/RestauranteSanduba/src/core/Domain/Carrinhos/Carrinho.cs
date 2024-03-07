using RestauranteSanduba.Core.Domain.Cardapios;
using RestauranteSanduba.Core.Domain.Clientes.Abstractions;
using RestauranteSanduba.Core.Domain.Common.Types;
using System;
using System.Collections.Generic;


namespace RestauranteSanduba.Core.Domain.Carrinhos
{
    public sealed class Carrinho : Entity<Guid>
    {
        public class ItemCarrinho : ValueObject
        {
            public int Codigo { get; init; }
            public Produto Produto { get; init; }
            public double Preco { get; init; }

            protected override IEnumerable<object> GetEqualityComponents()
            {
                yield return Codigo;
            }
        }

        private Carrinho(Guid id) : base(id) { }

        private readonly List<ItemCarrinho> _itens = new();

        public IReadOnlyCollection<ItemCarrinho> Itens => _itens;

        public Cliente Cliente { get; init; }

        public static Carrinho CriarCarrinho(Guid id, Cliente cliente)
        {
            var carrinho = new Carrinho(id)
            {
                Cliente = cliente,
            };

            return carrinho;
        }

        public override void ValidateEntity()
        {

        }
    }
}
