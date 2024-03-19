using ClienteDomain = RestauranteSanduba.Core.Domain.Clientes.Abstractions.Cliente;
using System;
using System.Linq;
using RestauranteSanduba.Core.Application.Abstraction.Clientes;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using RestauranteSanduba.Core.Domain.Clientes;
using Microsoft.Data.SqlClient;

namespace RestauranteSanduba.Infra.PersistenceGateway.SqlServer.Clientes
{
    public class ClienteRepository : IClientePersistenceGateway
    {
        private readonly InfrastructureDbContext _dbContext;

        public ClienteRepository(InfrastructureDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Guid CadastrarCliente(ClienteDomain cliente)
        {

            if (_dbContext.Clientes.Where(existente => existente.CPF == cliente.CPF.ToString()).Any())
                throw new Exception("Cliente já cadastrado!");

            _dbContext.Database.ExecuteSqlRaw($"Sp_AdicionaCliente @Id, @Tipo, @Cpf, @Nome, @Email, @Senha",
                new SqlParameter("@Id", cliente.Id),
                new SqlParameter("@Tipo", (int)cliente.Tipo),
                new SqlParameter("@Cpf", cliente.CPF.ToString()),
                new SqlParameter("@Nome", cliente.Nome),
                new SqlParameter("@Email", cliente.Email),
                new SqlParameter("@Senha", cliente.Senha));

            _dbContext.SaveChanges();

            return cliente.Id;
        }

        public List<ClienteDomain> ConsultarClientes()
        {
            return _dbContext.Clientes
                .Select(item => item.ToDomain())
                .ToList();
        }

        public ClienteDomain ConsultarCliente(Guid clienteId)
        {
            return _dbContext.Clientes
                .Where(cliente => cliente.Id == clienteId)
                .Select(item => item.ToDomain())
                .FirstOrDefault();
        }

        public ClienteDomain ConsultarCliente(CPF numeroDocumento)
        {
            return _dbContext.Clientes
                .Where(cliente => cliente.CPF == numeroDocumento.ToString())
                .Select(item => item.ToDomain())
                .FirstOrDefault();
        }
    }
}
