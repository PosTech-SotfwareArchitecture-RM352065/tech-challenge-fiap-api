using RestauranteSanduba.Core.Domain.Cardapios;

namespace RestauranteSanduba.Core.Application.Abstraction.Cardapios.RequestModel
{
    public record CadastroProdutoRequest
    {
        public Categoria categoria { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public double Preco { get; set; }
    }
}
