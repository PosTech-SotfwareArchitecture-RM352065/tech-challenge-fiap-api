namespace RestauranteSanduba.API.Clientes.Requests
{
    public record CadastroClienteRequest(string CPF, string Nome, string Email, string Senha);
}
