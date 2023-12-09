using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteSanduba.Core.Application.Abstraction.Pedidos.Response
{
    public record CriacaoPedidoResponse
    {
        public int NumeroPedido { get; set; }
        public double Total { get; set; }

        public CriacaoPedidoResponse(int numeroPedido, double total)
        {
            NumeroPedido = numeroPedido;
            Total = total;
        }
    }
}
