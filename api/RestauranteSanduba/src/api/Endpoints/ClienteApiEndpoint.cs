using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestauranteSanduba.Core.Application.Abstraction.Clientes;
using RestauranteSanduba.Core.Application.Abstraction.Clientes.RequestModel;
using RestauranteSanduba.Core.Application.Abstraction.Clientes.ResponseModel;
using Swashbuckle.AspNetCore.Annotations;

namespace RestauranteSanduba.API.Endpoints
{
    [ApiController]
    [Route("cliente")]
    public class ClienteApiEndpoint : ControllerBase
    {
        private readonly ILogger<ClienteApiEndpoint> _logger;
        private readonly ClienteController<string> clienteController;

        public ClienteApiEndpoint(ILogger<ClienteApiEndpoint> logger, ClienteController<string> clienteController)
        {
            _logger = logger;
            this.clienteController = clienteController;
        }

        [Authorize]
        [HttpGet(Name = "ConsultaClientePorCPF")]
        [SwaggerOperation(Summary = "Consulta dados do cliente")]
        [SwaggerResponse(200, "Dados do Cliente", typeof(ConsultaClienteResponse))]
        public IActionResult Get(string? numeroDocumento = null)
        {
            if (numeroDocumento is null)
            {
                return Ok(clienteController.ConsultarClientes());
            }
            else
            {
                var requestModel = new ConsultaClienteRequest { CPF = numeroDocumento };
                return Ok(clienteController.ConsultarCliente(requestModel));
            }
        }


        [HttpPost(Name = "CadastraCliente")]
        [SwaggerOperation(Summary = "Cria novo cliente")]
        [SwaggerResponse(200, "Identificação do cliente", typeof(CadastroClienteResponse))]
        public IActionResult Post(CadastroClienteRequest requestModel)
        {
            return Ok(clienteController.CadastrarCliente(requestModel));
        }
    }
}