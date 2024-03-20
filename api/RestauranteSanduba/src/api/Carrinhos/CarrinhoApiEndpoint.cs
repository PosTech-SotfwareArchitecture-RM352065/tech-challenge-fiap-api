using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestauranteSanduba.API.Carrinhos.Requests;
using RestauranteSanduba.Core.Application.Abstraction.Carrinhos;
using RestauranteSanduba.Core.Application.Abstraction.Carrinhos.RequestModel;
using RestauranteSanduba.Core.Application.Abstraction.Carrinhos.ResponseModel;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace RestauranteSanduba.API.Carrinhos
{
    [ApiController]
    [Route("carrinho")]
    public class CarrinhoApiEndpoint : ControllerBase
    {
        private readonly ILogger<CarrinhoApiEndpoint> _logger;
        private readonly CarrinhoController<string> CarrinhoController;

        public CarrinhoApiEndpoint(ILogger<CarrinhoApiEndpoint> logger, CarrinhoController<string> CarrinhoController)
        {
            _logger = logger;
            this.CarrinhoController = CarrinhoController;
        }

        [Authorize]
        [HttpGet(Name = "ConsultaCarrinho")]
        [SwaggerOperation(Summary = "Obtem produtos no carrinho")]
        [SwaggerResponse(200, "Itens no carrinho", typeof(List<ConsultaCarrinhoResponseModel>))]
        public IActionResult Get()
        {
            var sub = User.FindFirstValue("sub");
            Guid userId;

            if (!Guid.TryParse(sub, out userId))
            {
                _logger.LogError($"Erro ao obter usuário na sessão. Parametro sub: {sub}");
                return BadRequest("Usuário inválido! ");
            }

            var controllerRequest = new ConsultaCarrinhoRequest(userId);

            return Ok(CarrinhoController.ConsultarProdutos(controllerRequest));
        }

        [Authorize]
        [HttpPost(Name = "AdicionarProduto")]
        [SwaggerOperation(Summary = "Adicionar produto ao carrinho")]
        [SwaggerResponse(200, "Lista do carrinho", typeof(CadastroCarrinhoResponseModel))]
        public IActionResult Post(CadastroCarrinhoRequest request)
        {
            var sub = User.FindFirstValue("sub");
            Guid userId;

            if (!Guid.TryParse(sub, out userId))
            {
                _logger.LogError($"Erro ao obter usuário na sessão. Parametro sub: {sub}");
                return BadRequest("Usuário inválido! ");
            }

            var controllerRequest = new CadastroCarrinhoRequestModel(userId, request.ProdutoId);

            return Ok(CarrinhoController.CadastrarProduto(controllerRequest));
        }

        [Authorize]
        [HttpDelete(Name = "RemoveProduto")]
        [SwaggerOperation(Summary = "Remove produto do carrinho")]
        [SwaggerResponse(200, "Número do Produto", typeof(RemoveCarrinhoResponseModel))]
        public IActionResult Delete(RemoveCarrinhoRequest request)
        {
            var sub = User.FindFirstValue("sub");
            Guid userId;

            if (!Guid.TryParse(sub, out userId))
            {
                _logger.LogError($"Erro ao obter usuário na sessão. Parametro sub: {sub}");
                return BadRequest("Usuário inválido! ");
            }

            var controllerRequest = new RemoveCarrinhoRequestModel(userId, request.ProdutoId);

            return Ok(CarrinhoController.RemoverProduto(controllerRequest));
        }
    }
}