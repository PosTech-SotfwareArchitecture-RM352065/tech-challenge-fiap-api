using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteSanduba.Core.Application.Abstraction.Pedidos.RequestModel
{
    public record ConsultaPedidoPorClienteRequest (Guid ClienteId);
}
