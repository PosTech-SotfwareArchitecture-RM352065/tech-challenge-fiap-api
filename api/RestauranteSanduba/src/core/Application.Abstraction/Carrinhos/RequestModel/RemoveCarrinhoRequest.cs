using System;

namespace RestauranteSanduba.Core.Application.Abstraction.Carrinhos.RequestModel
{
    public record RemoveCarrinhoRequest(Guid ClienteId, Guid ProdutoId);
}
