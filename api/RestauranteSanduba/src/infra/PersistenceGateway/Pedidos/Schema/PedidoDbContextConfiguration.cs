using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RestauranteSanduba.Infra.PersistenceGateway.Pedidos.Schema
{
    internal class PedidoDbContextConfiguration : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder) 
        { 
            //builder.HasKey(pedido => pedido.Id);
            //builder.Property(pedido => pedido.Numero).IsRequired();
            //builder.HasOne(pedido => pedido.Cliente)
            //    .WithMany(cliente => cliente.Pedidos)
            //    .HasForeignKey(pedido => pedido.ClienteId);
        }
    }
}
