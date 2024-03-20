using RestauranteSanduba.Core.Application.Abstraction.Carrinhos.RequestModel;
using System.Collections.Generic;

namespace RestauranteSanduba.Core.Application.Abstraction.Carrinhos
{
    public abstract class CarrinhoController<T>
    {
        protected readonly ICarrinhoInteractor interactor;
        protected readonly CarrinhoPresenter<T> presenter;

        protected CarrinhoController(ICarrinhoInteractor interactor, CarrinhoPresenter<T> presenter)
        {
            this.interactor = interactor;
            this.presenter = presenter;
        }

        public abstract T CadastrarProduto(CadastroCarrinhoRequestModel requestModel);
        public abstract T RemoverProduto(RemoveCarrinhoRequestModel requestModel);
        public abstract T ConsultarProdutos(ConsultaCarrinhoRequest requestModel);

    }
}
