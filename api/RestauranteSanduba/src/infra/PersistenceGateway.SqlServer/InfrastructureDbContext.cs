using Microsoft.EntityFrameworkCore;
using RestauranteSanduba.Infra.PersistenceGateway.SqlServer.Cardapios.Schema;
using RestauranteSanduba.Infra.PersistenceGateway.SqlServer.Clientes.Schema;
using RestauranteSanduba.Infra.PersistenceGateway.SqlServer.Pedidos.Schema;

namespace RestauranteSanduba.Infra.PersistenceGateway.SqlServer
{
    public class InfrastructureDbContext : DbContext
    {
        public InfrastructureDbContext(DbContextOptions<InfrastructureDbContext> options) : base(options) { }

        internal DbSet<Cliente> Clientes { get; set; }
        internal DbSet<Produto> Produtos { get; set; }
        internal DbSet<Pedido> Pedidos { get; set; }
        internal DbSet<ItemPedido> ItensPedido { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new PedidoDbContextConfiguration());
        }
    }
}
