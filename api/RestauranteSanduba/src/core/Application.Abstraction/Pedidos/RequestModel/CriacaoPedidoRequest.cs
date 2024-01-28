using System;
using System.Collections.Generic;

namespace RestauranteSanduba.Core.Application.Abstraction.Pedidos.RequestModel
{
    public record CriacaoPedidoRequest
    {
        public Guid ClienteId { get; set; }
        public List<Guid> Itens { get; set; }
    }
}
