using System;

namespace RestauranteSanduba.Core.Application.Abstraction.Pedidos.RequestModel
{
    public record RemoveItemPedido (Guid Id, Guid ItemId);
}
