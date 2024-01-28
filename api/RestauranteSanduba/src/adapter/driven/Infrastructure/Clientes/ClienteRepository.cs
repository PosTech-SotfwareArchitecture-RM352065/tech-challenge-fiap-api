using Domain = RestauranteSanduba.Core.Domain.Clientes;
using Application = RestauranteSanduba.Core.Application.Abstraction.Clientes;
using Data = RestauranteSanduba.Adapter.Driven.Persistence.Clientes.Schema;
using System;
using System.Linq;
using RestauranteSanduba.Core.Application.Abstraction.Clientes;
using RestauranteSanduba.Adapter.Driven.Persistence;
using RestauranteSanduba.Adapter.Driven.Persistence.Clientes.Schema;

namespace RestauranteSanduba.Adapter.Driven.Persistence.Clientes
{
    public class ClienteRepository : IClientePersistenceGateway
    {
        private readonly InfrastructureDbContext _dbContext;

        public ClienteRepository(InfrastructureDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void CadastrarCliente(Domain.Abstractions.Cliente cliente)
        {
            _dbContext.Clientes.Add(Cliente.ToSchema(cliente));
            _dbContext.SaveChanges();
        }

        public Domain.Abstractions.Cliente ConsultarCliente(Guid idCliente)
        {
            return _dbContext.Clientes
                .Where(cliente => cliente.Id == idCliente)
                .Select(item => item.ToDomain())
                .FirstOrDefault();
        }

        public Domain.Abstractions.Cliente ConsultarCliente(Domain.CPF numeroDocumento)
        {
            return _dbContext.Clientes
                .Where(cliente => cliente.CPF == numeroDocumento.ToString())
                .Select(item => item.ToDomain())
                .FirstOrDefault();
        }
    }
}
