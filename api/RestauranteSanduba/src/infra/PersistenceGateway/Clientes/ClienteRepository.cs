using Domain = RestauranteSanduba.Core.Domain.Clientes;
using System;
using System.Linq;
using RestauranteSanduba.Core.Application.Abstraction.Clientes;
using RestauranteSanduba.Infra.PersistenceGateway.Clientes.Schema;
using System.Collections.Generic;

namespace RestauranteSanduba.Infra.PersistenceGateway.Clientes
{
    public class ClienteRepository : IClientePersistenceGateway
    {
        private readonly InfrastructureDbContext _dbContext;

        public ClienteRepository(InfrastructureDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Guid CadastrarCliente(Domain.Abstractions.Cliente cliente)
        {
            _dbContext.Clientes.Add(Cliente.ToSchema(cliente));
            _dbContext.SaveChanges();

            return cliente.Id;
        }

        public List<Domain.Abstractions.Cliente> ConsultarClientes()
        {
            return _dbContext.Clientes
                .Select(item => item.ToDomain())
                .ToList();
        }

        public Domain.Abstractions.Cliente ConsultarCliente(Guid id)
        {
            return _dbContext.Clientes
                .Where(cliente => cliente.Id == id)
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
