using RestauranteSanduba.Core.Domain.Common.Assertions;
using RestauranteSanduba.Core.Domain.Common.Types;
using System;

namespace RestauranteSanduba.Core.Domain.Cardapios
{
    public sealed class Produto : Entity<Guid>
    {
        private Produto(Guid id) : base(id) { }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public double Preco { get; private set; }
        public Categoria Categoria { get; private set; }

        public static Produto CriarProduto(Categoria categoria, string Nome, string Descricao, double Preco)
        {
            var novoProduto = new Produto(Guid.NewGuid())
            {
                Categoria = categoria,
                Nome = Nome,
                Descricao = Descricao,
                Preco = Preco
            };

            return novoProduto;
        }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (!(obj is Produto)) return false;
            return (Id == ((Produto)obj).Id);
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }

        public override void ValidateEntity()
        {
            AssertionConcern.AssertArgumentNotEmpty(Nome, "Nome inválido. Não deve ser vazio");
            AssertionConcern.AssertArgumentNotEmpty(Descricao, "Descrição inválida. Não deve ser vazia");
        }
    }
}
