namespace RestauranteSanduba.Core.Application.Abstraction.Cardapios.RequestModel
{
    public record CadastroProdutoRequest(string Categoria, string Nome, string Descricao, double Preco);
}
