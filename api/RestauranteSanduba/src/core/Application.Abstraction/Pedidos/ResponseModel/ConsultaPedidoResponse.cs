using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteSanduba.Core.Application.Abstraction.Pedidos.ResponseModel
{
    public record ConsultaPedidoResponse (Guid Id, int NumeroPedido, double Total, string Status);
}
