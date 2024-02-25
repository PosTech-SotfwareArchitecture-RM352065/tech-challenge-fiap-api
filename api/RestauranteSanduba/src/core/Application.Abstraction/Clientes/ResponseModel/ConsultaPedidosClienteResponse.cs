using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteSanduba.Core.Application.Abstraction.Clientes.ResponseModel
{
    public record ConsultaPedidosClienteResponse
    {
        public List<Guid>? Pedidos { get; set; }
    }
}
