using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestauranteSanduba.Core.Application.Pedidos;
using RestauranteSanduba.Core.Domain.Pedidos;
using RestauranteSanduba.Core.Domain.Pedidos.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace RestauranteSanduba.Adapter.Driven.API.Pedidos
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

        [HttpGet(Name = "ObtemPedido")]
        [SwaggerOperation(
            Summary = "Obtem pedido a partir do número de pedido",
            Description = "Consulta deve retornar os itens dentro de um pedido a partir do número informado",
            OperationId = "Get",
            Tags = new[] { "Pedido" })]
        [SwaggerResponse(200, "The random weather forecasts", typeof(Pedido))]
        public IActionResult Get(int numeroPedido)
        {
            return Ok(_pedidoService.ObtemPedido(numeroPedido));
        }
    }
}