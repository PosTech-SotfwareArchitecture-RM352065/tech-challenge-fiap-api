using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestauranteSanduba.Core.Application.Abstraction.Cardapios;
using RestauranteSanduba.Core.Application.Abstraction.Cardapios.RequestModel;
using RestauranteSanduba.Core.Application.Abstraction.Cardapios.ResponseModel;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;

namespace RestauranteSanduba.API.Cardapios
{
    [ApiController]
    [Route("cardapio")]
    public class CardapioApiEndpoint : ControllerBase
    {
        private readonly ILogger<CardapioApiEndpoint> _logger;
        private readonly CardapioController<string> cardapioController;

        public CardapioApiEndpoint(ILogger<CardapioApiEndpoint> logger, CardapioController<string> cardapioController)
        {
            _logger = logger;
            this.cardapioController = cardapioController;
        }

        [HttpGet(Name = "ConsultaCardapio")]
        [SwaggerOperation(Summary = "Obtem opções do cardápio")]
        [SwaggerResponse(200, "Itens do cardápio", typeof(List<ConsultaProdutoResponse>))]
        public IActionResult Get()
        {
            return new OkObjectResult(cardapioController.ConsultarProdutosAtivos());
        }

        [HttpPost(Name = "CadastraProduto")]
        [SwaggerOperation(Summary = "Cadastra novo Produto")]
        [SwaggerResponse(200, "Número do Produto", typeof(CadastroProdutoResponse))]
        public IActionResult Post(CadastroProdutoRequest requestModel)
        {
            return new OkObjectResult(cardapioController.CadastrarProduto(requestModel));
        }
    }
}