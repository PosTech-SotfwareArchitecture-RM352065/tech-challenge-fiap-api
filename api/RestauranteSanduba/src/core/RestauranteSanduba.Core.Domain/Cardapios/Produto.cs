using System;

namespace RestauranteSanduba.Core.Domain.Cardapios
{
    public class Produto
    {
        public Guid Codigo { get; private set; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public double Preco { get; private set; }
        public Categoria Categoria { get; private set; }

        public static Produto CriarProduto(Categoria categoria, string Nome, string Descricao, double Preco)
        {
            var novoProduto = new Produto()
            {
                Codigo = Guid.NewGuid(),
                Categoria = categoria,
                Nome = Nome,
                Descricao = Descricao,
                Preco = Preco
            };

            return novoProduto;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != typeof(Produto)) return false;
            return (this.Codigo == ((Produto)obj).Codigo);
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}
