using RestauranteSanduba.Core.Application.Abstraction.Cardapios.RequestModel;
using RestauranteSanduba.Core.Application.Abstraction.Cardapios.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteSanduba.Core.Application.Abstraction.Cardapios
{
    public abstract class CardapioController<T>
    {
        protected readonly ICardapioInteractor interactor;
        protected readonly CardapioPresenter<T> presenter;

        protected CardapioController(ICardapioInteractor interactor, CardapioPresenter<T> presenter)
        {
            this.interactor = interactor;
            this.presenter = presenter;
        }

        public abstract T CadastrarProduto(CadastroProdutoRequest requestModel);
        public abstract T InativarProduto(InativarProdutoRequest requestModel);
        public abstract T AtualizaProduto(AtualizaProdutoRequest requestModel);
        public abstract T ConsultarProduto(ConsultaProdutoRequest requestModel);
        public abstract T ConsultarProdutosAtivos();
        public abstract T ConsultarProdutos(List<ConsultaProdutoRequest> requestModel);

    }
}
