using RestauranteSanduba.Core.Domain.Cardapios;

namespace RestauranteSanduba.Core.Application.Cardapios.Abstractions.Request
{
    public record CadastroProdutoRequest
    {
        public Categoria categoria { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public double Preco { get; set; }
    }
}
