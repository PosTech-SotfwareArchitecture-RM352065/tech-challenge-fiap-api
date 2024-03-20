using System;

namespace RestauranteSanduba.Core.Application.Abstraction.Carrinhos.RequestModel
{
    public record RemoveCarrinhoRequestModel(Guid ClienteId, Guid ProdutoId);
}
