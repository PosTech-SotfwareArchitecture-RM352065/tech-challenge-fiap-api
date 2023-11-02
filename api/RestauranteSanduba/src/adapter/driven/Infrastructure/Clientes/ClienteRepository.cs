using Domain = RestauranteSanduba.Core.Domain.Clientes;
using Application = RestauranteSanduba.Core.Application.Clientes.Abstractions;
using Data = RestauranteSanduba.Adapter.Driven.Infrastructure.Clientes.Schema;
using System;
using System.Linq;

namespace RestauranteSanduba.Adapter.Driven.Infrastructure.Clientes
{
    public class ClienteRepository : Application.IClienteRepository
    {
        private readonly InfrastructureDbContext _dbContext;

        public ClienteRepository(InfrastructureDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void CadastrarCliente(Domain.Abstractions.Cliente cliente)
        {
            _dbContext.Clientes.Add(Data.Cliente.ToSchema(cliente));
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
