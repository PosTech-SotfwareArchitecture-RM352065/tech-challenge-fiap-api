using Microsoft.EntityFrameworkCore;
using RestauranteSanduba.Infra.PersistenceGateway.Cardapios.Schema;
using RestauranteSanduba.Infra.PersistenceGateway.Clientes.Schema;
using RestauranteSanduba.Infra.PersistenceGateway.Pedidos.Schema;

namespace RestauranteSanduba.Infra.PersistenceGateway
{
    public class InfrastructureDbContext : DbContext
    {
        public InfrastructureDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<ItemPedido> ItensPedido { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new PedidoDbContextConfiguration());
        }
    }
}
