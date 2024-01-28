using RestauranteSanduba.Core.Application.Abstraction.Cardapios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteSanduba.Adapter.Controller.Cardapios
{
    public class CardapioController
    {
        private ICardapioInputport interactor;

        public CardapioController(ICardapioInputport interactor)
        {
            this.interactor = interactor;
        }


    }
}
