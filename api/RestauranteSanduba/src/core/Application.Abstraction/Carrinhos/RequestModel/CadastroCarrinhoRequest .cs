using System;

namespace RestauranteSanduba.Core.Application.Abstraction.Carrinhos.RequestModel
{
    public record CadastroCarrinhoRequestModel(Guid ClienteId, Guid ProdutoId);
}
