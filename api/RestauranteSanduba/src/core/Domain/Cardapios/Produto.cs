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
        public bool Ativo { get; private set; }

        public static Produto CriarProduto(Guid id, Categoria categoria, string Nome, string Descricao, double Preco, bool ativo)
        {
            var novoProduto = new Produto(id)
            {
                Categoria = categoria,
                Nome = Nome,
                Descricao = Descricao,
                Preco = Preco,
                Ativo = ativo
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

        public void InativarProduto()
        {
            this.Ativo = false;
        }

        public override void ValidateEntity()
        {
            AssertionConcern.AssertArgumentNotEmpty(Nome, "Nome inválido. Não deve ser vazio");
            AssertionConcern.AssertArgumentNotEmpty(Descricao, "Descrição inválida. Não deve ser vazia");
        }
    }
}
