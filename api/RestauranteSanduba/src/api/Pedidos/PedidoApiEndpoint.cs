using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestauranteSanduba.API.Pedidos.Requests;
using RestauranteSanduba.Core.Application.Abstraction.Pedidos;
using RestauranteSanduba.Core.Application.Abstraction.Pedidos.RequestModel;
using RestauranteSanduba.Core.Application.Abstraction.Pedidos.ResponseModel;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Security.Claims;

namespace RestauranteSanduba.API.Pedidos
{
    [Authorize]
    [ApiController]
    [Route("pedido")]

    public class PedidoApiEndpoint : ControllerBase
    {
        private readonly ILogger<PedidoApiEndpoint> _logger;
        private readonly PedidoController<string> pedidoController;

        public PedidoApiEndpoint(ILogger<PedidoApiEndpoint> logger, PedidoController<string> pedidoController)
        {
            _logger = logger;
            this.pedidoController = pedidoController;
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Consulta pedido a partir do número de pedido")]
        [SwaggerResponse(200, "Dados do pedido", typeof(ConsultaPedidoResponse))]
        public IActionResult Get(Guid requestModel)
        {
            return Ok(pedidoController.ObtemPedido(new ConsultaPedidoRequest(requestModel)));
        }

        [HttpPost(Name = "CadastraPedido")]
        [SwaggerOperation(Summary = "Cadastra novo pedido")]
        [SwaggerResponse(200, "Id do pedido", typeof(CriacaoPedidoResponse))]
        public IActionResult Post(CriacaoPedidoRequest request)
        {
            var sub = User.FindFirstValue("sub");
            Guid userId;

            if (!Guid.TryParse(sub, out userId))
            {
                _logger.LogError($"Erro ao obter usuário na sessão. Parametro sub: {sub}");
                return BadRequest("Usuário inválido! ");
            }

            var controllerRequest = new CriacaoPedidoRequestModel(userId, request.Itens);

            return Ok(pedidoController.CriaPedido(controllerRequest));
        }

        [HttpPut(Name = "AtualizaPedido")]
        [SwaggerOperation(Summary = "Cadastra novo pedido")]
        [SwaggerResponse(200, "Status pedido", typeof(AtualizaPedidoResponse))]
        public IActionResult Put(AtualizaPedidoRequest requestModel)
        {
            var sub = User.FindFirstValue("sub");
            Guid userId;

            if (!Guid.TryParse(sub, out userId))
            {
                _logger.LogError($"Erro ao obter usuário na sessão. Parametro sub: {sub}");
                return BadRequest("Usuário inválido! ");
            }

            return Ok();
        }
    }
}