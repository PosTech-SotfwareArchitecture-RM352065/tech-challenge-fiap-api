using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestauranteSanduba.API.Clientes.Requests;
using RestauranteSanduba.Core.Application.Abstraction.Clientes;
using RestauranteSanduba.Core.Application.Abstraction.Clientes.RequestModel;
using RestauranteSanduba.Core.Application.Abstraction.Clientes.ResponseModel;
using Swashbuckle.AspNetCore.Annotations;

namespace RestauranteSanduba.API.Clientes
{
    [Authorize]
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

        [AllowAnonymous]
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

        [AllowAnonymous]
        [HttpPost(Name = "CadastraCliente")]
        [SwaggerOperation(Summary = "Cria novo cliente")]
        [SwaggerResponse(200, "Identificação do cliente", typeof(CadastroClienteResponse))]
        public IActionResult Post(CadastroClienteRequest request)
        {
            if (string.IsNullOrEmpty(request.CPF) || string.IsNullOrEmpty(request.Nome) || string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Senha))
            {
                return BadRequest(request);
            }

            var controllerRequest = new CadastroClienteRequestModel(request.CPF, request.Nome, request.Email, request.Senha);

            return Ok(clienteController.CadastrarCliente(controllerRequest));
        }
    }
}