using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestauranteSanduba.Core.Application.Abstraction.Pedidos;
using RestauranteSanduba.Core.Application.Abstraction.Pedidos.RequestModel;
using RestauranteSanduba.Core.Application.Abstraction.Pedidos.ResponseModel;
using Swashbuckle.AspNetCore.Annotations;
using System;

namespace RestauranteSanduba.API.Endpoints
{
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

        [HttpGet]
        [SwaggerOperation(Summary = "Consulta pedido a partir do número de pedido")]
        [SwaggerResponse(200, "Dados do pedido", typeof(ConsultaPedidoResponse))]
        public IActionResult Get()
        {
            return Ok();
        }

        [HttpPost(Name = "CadastraPedido")]
        [SwaggerOperation(Summary = "Cadastra novo pedido")]
        [SwaggerResponse(200, "Id do pedido", typeof(CriacaoPedidoResponse))]
        public IActionResult Post(CriacaoPedidoRequest requestModel)
        {
            return Ok(pedidoController.CriaPedido(requestModel));
        }

        [HttpPut(Name = "AtualizaPedido")]
        [SwaggerOperation(Summary = "Cadastra novo pedido")]
        [SwaggerResponse(200, "Status pedido", typeof(AtualizaPedidoResponse))]
        public IActionResult Put(AtualizaPedidoRequest requestModel)
        {
            return Ok();
        }
    }
}