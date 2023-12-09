using System;
using TechTalk.SpecFlow;

namespace RestauranteSanduba.Test.Core.ApplicationTest.Cardapio
{
    [Binding]
    public class AtualizacaoDeProdutosStepDefinitions
    {
        [Given(@"não vamos mais oferecer lanche chamado ""([^""]*)""")]
        public void GivenNaoVamosMaisOferecerLancheChamado(string nome)
        {
            throw new PendingStepException();
        }

        [When(@"remover o lanche do cardapio")]
        public void WhenRemoverOLancheDoCardapio()
        {
            throw new PendingStepException();
        }

        [Then(@"deve retornar o produto como inativo")]
        public void ThenDeveRetornarOProdutoComoInativo()
        {
            throw new PendingStepException();
        }

        [Given(@"um lanche já existente chamado ""([^""]*)""")]
        public void GivenUmLancheJaExistenteChamado(string nome)
        {
            throw new PendingStepException();
        }

        [When(@"for informado o código e o novo preço (.*)")]
        public void WhenForInformadoOCodigoEONovoPreco(double preco)
        {
            throw new PendingStepException();
        }

        [Then(@"deve retornar que a operação foi finalizada com sucesso")]
        public void ThenDeveRetornarQueAOperacaoFoiFinalizadaComSucesso()
        {
            throw new PendingStepException();
        }

        [When(@"for informado o código e um novo preço (.*)")]
        public void WhenForInformadoOCodigoEUmNovoPreco(double preco)
        {
            throw new PendingStepException();
        }

        [Then(@"deve retornar erro informando o preço inválido")]
        public void ThenDeveRetornarErroInformandoOPrecoInvalido()
        {
            throw new PendingStepException();
        }
    }
}
