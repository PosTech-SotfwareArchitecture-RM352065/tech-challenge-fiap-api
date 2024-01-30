using Microsoft.EntityFrameworkCore;
using RestauranteSanduba.Infra.PersistenceGateway.Cardapios.Schema;
using RestauranteSanduba.Infra.PersistenceGateway.Clientes.Schema;
using RestauranteSanduba.Infra.PersistenceGateway.Pedidos.Schema;

namespace RestauranteSanduba.Infra.PersistenceGateway
{
    public class InfrastructureDbContext : DbContext
    {
        public InfrastructureDbContext(DbContextOptions options) : base(options) { }

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
