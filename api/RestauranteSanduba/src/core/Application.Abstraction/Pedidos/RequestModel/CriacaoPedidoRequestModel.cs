using System;
using System.Collections.Generic;

namespace RestauranteSanduba.Core.Application.Abstraction.Pedidos.RequestModel
{
    public record CriacaoPedidoRequestModel(Guid ClienteId, List<Guid> Itens);
}
