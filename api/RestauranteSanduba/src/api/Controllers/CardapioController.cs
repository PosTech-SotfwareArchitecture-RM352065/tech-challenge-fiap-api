using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestauranteSanduba.Core.Application.Abstraction.Cardapios;
using RestauranteSanduba.Core.Application.Abstraction.Cardapios.RequestModel;
using RestauranteSanduba.Core.Application.Abstraction.Cardapios.ResponseModel;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;

namespace RestauranteSanduba.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CardapioController : ControllerBase
    {
        private readonly ILogger<CardapioController> _logger;
        private readonly ICardapioInputport _cardapioService;

        public CardapioController(ILogger<CardapioController> logger, ICardapioInputport cardapioService)
        {
            _logger = logger;
            _cardapioService = cardapioService;
        }

        [HttpGet(Name = "ConsultaCardapio")]
        [SwaggerOperation(
            Summary = "Obtem opções do cardápio",
            Description = "Consulta deve retornar os itens ativos do cardápio",
            OperationId = "Get",
            Tags = new[] { "Cardapio" })]
        [SwaggerResponse(200, "Itens do cardápio", typeof(List<ConsultaProdutoResponse>))]
        public IActionResult Get()
        {
            return Ok(_cardapioService.ConsultarProdutosAtivos());
        }

        [HttpPost(Name = "CadastraProduto")]
        [SwaggerOperation(
            Summary = "Cadastra novo Produto",
            Description = "Cadastra novo produto no cardápio",
            OperationId = "Post",
            Tags = new[] { "Cardapio" })]
        [SwaggerResponse(200, "Número do Produto", typeof(CadastroProdutoResponse))]
        public IActionResult Post(CadastroProdutoRequest request)
        {
            return Ok(_cardapioService.CadastrarProduto(request));
        }
    }
}