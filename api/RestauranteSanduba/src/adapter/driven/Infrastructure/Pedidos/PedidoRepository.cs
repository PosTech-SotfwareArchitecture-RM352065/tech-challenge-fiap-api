using Microsoft.EntityFrameworkCore;
using Domain = RestauranteSanduba.Core.Domain.Pedidos;
using Application = RestauranteSanduba.Core.Application.Abstraction.Pedidos;
using Data = RestauranteSanduba.Adapter.Driven.Persistence.Pedidos.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using RestauranteSanduba.Core.Application.Abstraction.Pedidos;
using RestauranteSanduba.Adapter.Driven.Persistence.Pedidos.Schema;

namespace RestauranteSanduba.Adapter.Driven.Persistence.Pedidos
{
    public class PedidoRepository : IPedidoPersistenceGateway
    {
        private readonly InfrastructureDbContext _dbContext;

        public PedidoRepository(InfrastructureDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Domain.Pedido ConsultaPedido(int numeroPedido)
        {
            return _dbContext.Pedidos
                .Include(item => item.Cliente)
                .Include(item => item.Items)
                .Where(item => item.Numero == numeroPedido)
                .Select(item => item.ToDomain())
                .FirstOrDefault();
        }

        public List<Domain.Pedido> ConsultaPedidosPorCliente(Guid clienteId)
        {
            return _dbContext.Pedidos
            .Include(item => item.Cliente)
            .Include(item => item.Items)
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
            _dbContext.Add(Pedido.ToSchema(pedido));
            _dbContext.SaveChanges();
        }
    }
}
