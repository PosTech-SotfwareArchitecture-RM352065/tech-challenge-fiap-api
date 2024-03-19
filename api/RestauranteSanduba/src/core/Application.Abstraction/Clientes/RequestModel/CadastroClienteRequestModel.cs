namespace RestauranteSanduba.Core.Application.Abstraction.Clientes.RequestModel
{
    public record CadastroClienteRequestModel(string CPF, string Nome, string Email, string Senha);
}
