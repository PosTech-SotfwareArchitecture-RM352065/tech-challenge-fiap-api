using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteSanduba.Core.Application.Cardapios.Abstractions.Response
{
    public record CadastroProdutoResponse
    {
        public Guid Id { get; set; }
    }
}
