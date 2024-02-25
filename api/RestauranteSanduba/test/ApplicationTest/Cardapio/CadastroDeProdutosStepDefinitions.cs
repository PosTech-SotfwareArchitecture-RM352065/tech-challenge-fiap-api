using Moq;
using RestauranteSanduba.Core.Application.Cardapios;
using RestauranteSanduba.Core.Domain.Cardapios;
using System;
using TechTalk.SpecFlow;
using Xunit;
using RestauranteSanduba.Core.Application.Abstraction.Cardapios;
using RestauranteSanduba.Core.Application.Abstraction.Cardapios.RequestModel;
using RestauranteSanduba.Core.Application.Abstraction.Cardapios.ResponseModel;

namespace RestauranteSanduba.Test.Core.ApplicationTest.Cardapio
{
    [Binding]
    public class CadastroDeProdutosStepDefinitions
    {
        [ThreadStatic]
        private static CardapioInteractor cardapioInteractor;
        [ThreadStatic]
        private static Mock<ICardapioPersistenceGateway> cardapioPersistenceGateway;
        [ThreadStatic]
        private static CadastroProdutoRequest request;
        [ThreadStatic]
        private static Func<CadastroProdutoResponse> action;
        [ThreadStatic]
        private static CadastroProdutoResponse response;

        [BeforeScenario]
        public static void SetupScenario()
        {
            cardapioPersistenceGateway = new Mock<ICardapioPersistenceGateway>();
            cardapioInteractor = new CardapioInteractor(cardapioPersistenceGateway.Object);
        }

        [AfterScenario]
        public static void DisposeScenario()
        {
            cardapioPersistenceGateway = null;
            cardapioInteractor = null;
        }

        [Given(@"temos um novo ""([^""]*)"" chamado ""([^""]*)"" com a descrição de ""([^""]*)"" e com preço de (.*)")]
        public void GivenTemosProdutoComNomeEDescricaoEPrecoValidos(string categoria, string nome, string descricao, double preco)
        {
            cardapioPersistenceGateway.Setup(repo => repo.CadastrarProduto(It.IsAny<Produto>()));

            Categoria categoriaLanche;
            Assert.True(Enum.TryParse(categoria, out categoriaLanche));

            request = new
            (
                Categoria: categoria,
                Nome: nome,
                Descricao: descricao,
                Preco: preco
            );
        }

        [When(@"adicionar o novo lanche no cardápio")]
        public void WhenAdicionarONovoLancheNoCardapio()
        {
            action = () => cardapioInteractor.CadastrarProduto(request);
        }

        [Then(@"deve retornar o novo código cadastrado")]
        public void ThenDeveRetornarONovoCodigoCadastrado()
        {
            response = action.Invoke();

            cardapioPersistenceGateway.Verify(repo => repo.CadastrarProduto(It.IsAny<Produto>()), Times.Once);
            Assert.IsType<Guid>(response.Id);
        }

        [Given(@"temos um lanche chamado ""([^""]*)"" já cadastrado")]
        public void GivenTemosUmLancheComOMesmoNomeJaCadastrado(string nome)
        {
            var produtoExistente = Produto.CriarProduto(Guid.NewGuid(), Categoria.Lanche, nome, "Nosso lanche gigante", 15.99, true);
            cardapioPersistenceGateway.Setup(repo => repo.ConsultarProduto(produtoExistente.Nome)).Returns(produtoExistente);

            request = new CadastroProdutoRequest(
                Categoria: "Lanche",
                Nome: "Mega Lanche",
                Descricao: "Nosso lanche gigante",
                Preco: 15.99
            );
        }

        [When(@"adicionar o lanche existente no cardápio")]
        public void WhenAdicionarLancheExistenteNoCardapio()
        {
            action = () => cardapioInteractor.CadastrarProduto(request);
        }

        [Then(@"deve retornar erro informando a duplicidade")]
        public void ThenDeveRetornarErroInformandoADuplicidade()
        {
            Assert.Throws<ProdutoDuplicadoException>(() =>
            {
                response = action.Invoke();
            });

            cardapioPersistenceGateway.Verify(repo => repo.ConsultarProduto(It.IsAny<string>()), Times.Once);
            cardapioPersistenceGateway.Verify(repo => repo.CadastrarProduto(It.IsAny<Produto>()), Times.Never);
        }

        [Given(@"temos um novo ""([^""]*)"" chamado ""([^""]*)"" com a descrição de vazia e com preço de (.*)")]
        public void GivenTemosUmNovoProdutoComADescricaoInvalida(string categoria, string nome, double preco)
        {
            cardapioPersistenceGateway.Setup(repo => repo.CadastrarProduto(It.IsAny<Produto>()));

            request = new CadastroProdutoRequest(
                Categoria: categoria,
                Nome: nome,
                Descricao: string.Empty,
                Preco: preco
            );
        }

        [Then(@"deve retornar erro informando a descrição inválida")]
        public void ThenDeveRetornarErroInformandoADescricaoInvalida()
        {
            Assert.Throws<ProdutoDomainException>(() =>
            {
                response = action.Invoke();
            });

            cardapioPersistenceGateway.Verify(repo => repo.CadastrarProduto(It.IsAny<Produto>()), Times.Never);
        }
    }
}
