using RestauranteSanduba.Core.Application.Abstraction.Cardapios.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteSanduba.Core.Application.Abstraction.Cardapios
{
    public abstract class ICardapioOutputPort<T>
    {
        public abstract T Present(CadastroProdutoResponse response);
    }
}
