using System;

namespace RestauranteSanduba.Core.Application.Abstraction.Carrinhos.RequestModel
{
    public record CadastroCarrinhoRequest(Guid ClienteId, Guid ProdutoId);
}
