using Microsoft.EntityFrameworkCore;
using RestauranteSanduba.Adapter.Driven.Persistence.Cardapios.Schema;
using RestauranteSanduba.Adapter.Driven.Persistence.Clientes.Schema;
using RestauranteSanduba.Adapter.Driven.Persistence.Pedidos.Schema;

namespace RestauranteSanduba.Adapter.Driven.Persistence
{
    public class InfrastructureDbContext : DbContext
    {
        public InfrastructureDbContext(DbContextOptions options) : base(options)
        {

            base.Database.Migrate();
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<ItemPedido> ItensPedido { get; set; }
    }
}
