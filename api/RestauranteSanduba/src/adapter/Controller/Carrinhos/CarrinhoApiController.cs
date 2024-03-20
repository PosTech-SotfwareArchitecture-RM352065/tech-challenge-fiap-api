using RestauranteSanduba.Core.Application.Abstraction.Carrinhos;
using RestauranteSanduba.Core.Application.Abstraction.Carrinhos.RequestModel;

namespace RestauranteSanduba.Adapter.ApiAdapter.Carrinhos
{
    public sealed class CarrinhoApiController : CarrinhoController<string>
    {
        private new readonly ICarrinhoInteractor interactor;
        private new readonly CarrinhoPresenter<string> presenter;

        public CarrinhoApiController(ICarrinhoInteractor interactor, CarrinhoPresenter<string> presenter) : base(interactor, presenter)
        {
            this.interactor = interactor;
            this.presenter = presenter;
        }

        public override string CadastrarProduto(CadastroCarrinhoRequestModel requestModel)
        {
            var responseModel = interactor.CadastrarProduto(requestModel);
            return presenter.Present(responseModel);
        }

        public override string ConsultarProdutos(ConsultaCarrinhoRequest requestModel)
        {
            var responseModel = interactor.ConsultarProdutos(requestModel);
            return presenter.Present(responseModel);
        }

        public override string RemoverProduto(RemoveCarrinhoRequestModel requestModel)
        {
            var responseModel = interactor.RemoverProduto(requestModel);
            return presenter.Present(responseModel);
        }
    }
}
