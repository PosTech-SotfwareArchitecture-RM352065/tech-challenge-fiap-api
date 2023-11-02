using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestauranteSanduba.Core.Application.Pedidos.Abstractions;
using RestauranteSanduba.Core.Application.Pedidos.Request;
using RestauranteSanduba.Core.Application.Pedidos.Response;
using RestauranteSanduba.Core.Domain.Pedidos;
using Swashbuckle.AspNetCore.Annotations;
using System;

namespace RestauranteSanduba.Adapter.Driven.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PedidoController : ControllerBase
    {
        private readonly ILogger<PedidoController> _logger;
        private readonly IPedidoService _pedidoService;

        public PedidoController(ILogger<PedidoController> logger, IPedidoService pedidoService)
        {
            _logger = logger;
            _pedidoService = pedidoService;
        }

        [HttpGet(Name = "ConsultaPedido")]
        [SwaggerOperation(
            Summary = "Consulta pedido a partir do número de pedido",
            Description = "Consulta deve retornar os itens dentro de um pedido a partir do número informado",
            OperationId = "Get",
            Tags = new[] { "Pedido" })]
        [SwaggerResponse(200, "Pedido com código", typeof(Pedido))]
        public IActionResult Get(int numeroPedido)
        {
            return Ok(_pedidoService.ObtemPedido(numeroPedido));
        }

        [HttpPost(Name = "CadastraPedido")]
        [SwaggerOperation(
            Summary = "Cadastra novo pedido",
            Description = "Criação de novo pedido com itens escolhidos (Lanche, acompanhamento, bedido e sobremesa)",
            OperationId = "Post",
            Tags = new[] { "Pedido" })]
        [SwaggerResponse(200, "Número do pedido", typeof(CriacaoPedidoResponse))]
        public IActionResult Post(CriacaoPedidoRequest pedido)
        {
            return Ok(_pedidoService.CriaPedido(pedido));
        }
    }
}