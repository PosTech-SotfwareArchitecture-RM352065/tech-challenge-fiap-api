using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteSanduba.Core.Application.Abstraction.Clientes.RequestModel
{
    public record ConsultaClienteRequest
    {
        public string CPF { get; set; }
    }
}
