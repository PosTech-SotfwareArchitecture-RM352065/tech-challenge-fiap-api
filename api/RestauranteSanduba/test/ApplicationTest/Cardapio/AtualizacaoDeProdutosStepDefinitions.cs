using Moq;
using RestauranteSanduba.Core.Application.Abstraction.Cardapios;
using RestauranteSanduba.Core.Application.Abstraction.Cardapios.RequestModel;
using RestauranteSanduba.Core.Application.Abstraction.Cardapios.ResponseModel;
using RestauranteSanduba.Core.Application.Cardapios;
using RestauranteSanduba.Core.Domain.Cardapios;
using RestauranteSanduba.Core.Domain.Common.Exceptions;
using System;
using TechTalk.SpecFlow;
using Xunit;

namespace RestauranteSanduba.Test.Core.ApplicationTest.Cardapio
{
    [Binding]
    public class AtualizacaoDeProdutosStepDefinitions
    {
        [ThreadStatic]
        private static CardapioInteractor cardapioInteractor;
        [ThreadStatic]
        private static Mock<ICardapioPersistenceGateway> cardapioPersistenceGateway;
        [ThreadStatic]
        private static AtualizaProdutoRequest atualizarRequest;
        [ThreadStatic]
        private static InativarProdutoRequest inativarRequest;
        [ThreadStatic]
        private static Func<ConsultaProdutoResponse> action;

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

        [Given(@"não vamos mais oferecer ""([^""]*)"" chamado ""([^""]*)""")]
        public void GivenNaoVamosMaisOferecerLancheChamado(string categoria, string nome)
        {
            Categoria categoriaLanche;
            Assert.True(Enum.TryParse(categoria, true, out categoriaLanche));

            var produtoInativo = Produto.CriarProduto(Guid.NewGuid(), categoriaLanche, nome, "Descrição", 9.99, false);

            cardapioPersistenceGateway
                .Setup(repo => repo.InativarProduto(It.IsAny<Guid>()))
                .Returns(() => produtoInativo);

            inativarRequest = new
            (
                Id: produtoInativo.Id
            );
        }

        [When(@"remover o lanche do cardapio")]
        public void WhenRemoverOLancheDoCardapio()
        {
            action = () => cardapioInteractor.InativarProduto(inativarRequest);
        }

        [Then(@"deve retornar o produto como inativo")]
        public void ThenDeveRetornarOProdutoComoInativo()
        {
            var response = action.Invoke();

            Assert.False(response.Ativo);
            Assert.Equal(inativarRequest.Id, response.Id);
        }

        [Given(@"um ""([^""]*)"" já existente chamado ""([^""]*)"" pelo preço de (.*) com o novo preço (.*)")]
        public void GivenUmLancheJaExistenteChamado(string categoria, string nome, double precoAntigo, double precoNovo)
        {
            Categoria categoriaLanche;
            Assert.True(Enum.TryParse(categoria, true, out categoriaLanche));

            var produtoAntigo = Produto.CriarProduto(Guid.NewGuid(), categoriaLanche, nome, "Descrição", precoAntigo, true);
            var produtoAtualizado = Produto.CriarProduto(produtoAntigo.Id, produtoAntigo.Categoria, produtoAntigo.Nome, produtoAntigo.Descricao, precoNovo, produtoAntigo.Ativo);

            cardapioPersistenceGateway
                .Setup(repo => repo.ConsultarProduto(produtoAntigo.Id))
                .Returns(produtoAntigo);

            cardapioPersistenceGateway
                .Setup(repo => repo.AtualizarProduto(produtoAtualizado))
                .Returns(produtoAtualizado);

            atualizarRequest = new
            (
                Id: produtoAtualizado.Id,
                Categoria: produtoAtualizado.Categoria,
                Nome: produtoAtualizado.Nome,
                Descricao: produtoAtualizado.Descricao,
                Preco: produtoAtualizado.Preco
            );
        }

        [When(@"for informado os dados de atualização")]
        public void WhenForInformadoOCodigoEONovoPreco()
        {
            action = () => cardapioInteractor.AtualizaProduto(atualizarRequest);
        }

        [Then(@"deve retornar que a operação foi finalizada com sucesso")]
        public void ThenDeveRetornarQueAOperacaoFoiFinalizadaComSucesso()
        {
            var response = action.Invoke();

            Assert.Equal(atualizarRequest.Id, response.Id);
            Assert.Equal(atualizarRequest.Preco, response.Preco);
        }

        [Then(@"deve retornar erro informando o preço inválido")]
        public void ThenDeveRetornarErroInformandoOPrecoInvalido()
        {
            Assert.Throws<DomainException>(() =>
            {
                action.Invoke();
            });
        }
    }
}
