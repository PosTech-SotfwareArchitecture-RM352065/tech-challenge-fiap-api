using System;

namespace RestauranteSanduba.Core.Application.Abstraction.Pedidos.RequestModel
{
    public record AtualizaPedidoRequest(Guid Id, string Status);
}
