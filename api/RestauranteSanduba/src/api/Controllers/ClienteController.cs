using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestauranteSanduba.Core.Application.Abstraction.Clientes;
using RestauranteSanduba.Core.Application.Abstraction.Clientes.Request;
using RestauranteSanduba.Core.Application.Abstraction.Clientes.Response;
using Swashbuckle.AspNetCore.Annotations;

namespace RestauranteSanduba.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly ILogger<ClienteController> _logger;
        private readonly IClienteService _clienteService;

        public ClienteController(ILogger<ClienteController> logger, IClienteService clienteService)
        {
            _logger = logger;
            _clienteService = clienteService;
        }

        [HttpGet(Name = "ConsultaCliente")]
        [SwaggerOperation(
            Summary = "Consulta dados do cliente",
            Description = "Consulta deve retornar nome e codigo de identificação a partir de um CPF",
            OperationId = "Get",
            Tags = new[] { "Cliente" })]
        [SwaggerResponse(200, "Dados do Cliente", typeof(ConsultaClienteResponse))]
        public IActionResult Get(string numeroDocumento)
        {
            var request = new ConsultaClienteRequest { CPF = numeroDocumento };
            return Ok(_clienteService.ConsultarCliente(request));
        }

        [HttpPost(Name = "CadastraCliente")]
        [SwaggerOperation(
            Summary = "Cria novo cliente",
            Description = "Cadastro de novo cliente",
            OperationId = "Post",
            Tags = new[] { "Cliente" })]
        [SwaggerResponse(200, "Id do Cliente", typeof(CadastroClienteResponse))]
        public IActionResult Post(CadastroClienteRequest request)
        {
            return Ok(_clienteService.CadastrarCliente(request));
        }
    }
}