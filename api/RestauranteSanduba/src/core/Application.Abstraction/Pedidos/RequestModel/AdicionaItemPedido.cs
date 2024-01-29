using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteSanduba.Core.Application.Abstraction.Pedidos.RequestModel
{
    public record AdicionaItemPedido(Guid Id, Guid ItemId);
}
