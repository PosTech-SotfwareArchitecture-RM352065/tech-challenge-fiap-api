using Microsoft.EntityFrameworkCore;
using RestauranteSanduba.Adapter.Driven.Infrastructure.Cardapios.Schema;
using RestauranteSanduba.Adapter.Driven.Infrastructure.Clientes.Schema;
using RestauranteSanduba.Adapter.Driven.Infrastructure.Pedidos.Schema;

namespace RestauranteSanduba.Adapter.Driven.Infrastructure
{
    public class InfrastructureDbContext : DbContext
    {
        public InfrastructureDbContext(DbContextOptions options) : base(options) { 
        
            base.Database.Migrate();
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<ItemPedido> ItensPedido { get; set; }
    }
}
