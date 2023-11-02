using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteSanduba.Core.Application.Clientes.Abstractions.Request
{
    public record CadastroClienteRequest
    {
        public string CPF { get; set; }
        public string Nome { get; set; }
        public string Email { get; set;}
    }
}
