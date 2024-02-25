using Microsoft.EntityFrameworkCore;
using Domain = RestauranteSanduba.Core.Domain.Pedidos;
using System;
using System.Collections.Generic;
using System.Linq;
using RestauranteSanduba.Core.Application.Abstraction.Pedidos;
using RestauranteSanduba.Infra.PersistenceGateway.SqlServer.Pedidos.Schema;

namespace RestauranteSanduba.Infra.PersistenceGateway.SqlServer.Pedidos
{
    public class PedidoRepository : IPedidoPersistenceGateway
    {
        private readonly InfrastructureDbContext _dbContext;

        public PedidoRepository(InfrastructureDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Domain.Pedido ConsultaPedido(Guid id)
        {
            return _dbContext.Pedidos
                .Include(item => item.Cliente)
                .Include(item => item.Itens)
                .Where(item => item.Id == id)
                .Select(item => item.ToDomain())
                .FirstOrDefault();
        }

        public List<Domain.Pedido> ConsultaPedidosPorCliente(Guid clienteId)
        {
            return _dbContext.Pedidos
            .Include(item => item.Cliente)
            .Include(item => item.Itens)
            .Where(item => item.Cliente.Id == clienteId)
            .Select(item => Domain.Pedido.CriarPedido(item.Id, item.Cliente.ToDomain(), item.Numero))
            .ToList();
        }

        public int ConsultaProximoNumeroPedido()
        {
            return _dbContext.Pedidos.Count() + 1;
        }

        public void CadastraPedido(Domain.Pedido pedido)
        {
            _dbContext.Pedidos.Add(Pedido.ToSchema(pedido));
            _dbContext.SaveChanges();
        }

        public List<Domain.Pedido> ConsultaPedidoPorStatus(string status)
        {
            return _dbContext.Pedidos
                .Include(item => item.Cliente)
                .Include(item => item.Itens)
                .Where(item => item.Status == (int)Enum.Parse(typeof(Domain.StatusPedido), status))
                .Select(item => Domain.Pedido.CriarPedido(item.Id, item.Cliente.ToDomain(), item.Numero))
                .ToList();
        }
    }
}
