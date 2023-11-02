using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteSanduba.Core.Application.Cardapios.Abstractions.Request
{
    public record ConsultaProdutoRequest
    {
        public Guid Id { get; set; }
    }
}
