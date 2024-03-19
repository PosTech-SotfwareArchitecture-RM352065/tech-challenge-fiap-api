using System.Collections.Generic;
using System;

namespace RestauranteSanduba.API.Pedidos.Requests
{
    public record CriacaoPedidoRequest(List<Guid> Itens);
}
