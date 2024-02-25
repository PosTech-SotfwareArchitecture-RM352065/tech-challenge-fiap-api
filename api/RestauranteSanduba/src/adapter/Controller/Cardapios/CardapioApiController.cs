using RestauranteSanduba.Core.Application.Abstraction.Cardapios;
using RestauranteSanduba.Core.Application.Abstraction.Cardapios.RequestModel;

namespace RestauranteSanduba.Adapter.ApiAdapter.Cardapios
{
    public sealed class CardapioApiController : CardapioController<string>
    {
        private new readonly ICardapioInteractor interactor;
        private new readonly CardapioPresenter<string> presenter;

        public CardapioApiController(ICardapioInteractor interactor, CardapioPresenter<string> presenter) : base(interactor, presenter)
        {
            this.interactor = interactor;
            this.presenter = presenter;
        }

        public override string AtualizaProduto(AtualizaProdutoRequest requestModel)
        {
            var responseModel = interactor.AtualizaProduto(requestModel);
            return presenter.Present(responseModel);
        }

        public override string CadastrarProduto(CadastroProdutoRequest requestModel)
        {
            var responseModel = interactor.CadastrarProduto(requestModel);
            return presenter.Present(responseModel);
        }

        public override string ConsultarProduto(ConsultaProdutoRequest requestModel)
        {
            var responseModel = interactor.ConsultarProduto(requestModel);
            return presenter.Present(responseModel);
        }

        public override string ConsultarProdutos(List<ConsultaProdutoRequest> requestModel)
        {
            var responseModel = interactor.ConsultarProdutos(requestModel);
            return presenter.Present(responseModel);
        }

        public override string ConsultarProdutosAtivos()
        {
            var responseModel = interactor.ConsultarProdutosAtivos();
            return presenter.Present(responseModel);
        }

        public override string InativarProduto(InativarProdutoRequest requestModel)
        {
            var responseModel = interactor.InativarProduto(requestModel);
            return presenter.Present(responseModel);
        }
    }
}
