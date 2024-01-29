using System;
using System.Collections.Generic;

namespace RestauranteSanduba.Core.Application.Abstraction.Pedidos.RequestModel
{
    public record CriacaoPedidoRequest (Guid ClienteId, List<Guid> Itens);
}
