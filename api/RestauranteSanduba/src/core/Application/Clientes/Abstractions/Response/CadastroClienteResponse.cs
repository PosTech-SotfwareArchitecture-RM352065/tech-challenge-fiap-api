using System;

namespace RestauranteSanduba.Core.Application.Clientes.Abstractions.Response
{
    public record CadastroClienteResponse
    {
        public Guid Id { get; set; }
    }
}
