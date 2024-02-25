using Microsoft.EntityFrameworkCore;
using Domain = RestauranteSanduba.Core.Domain.Pedidos;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using RestauranteSanduba.Infra.PersistenceGateway.SqlServer.Cardapios.Schema;

namespace RestauranteSanduba.Infra.PersistenceGateway.SqlServer.Pedidos.Schema
{
    [PrimaryKey(nameof(PedidoId), nameof(Codigo))]
    public class ItemPedido
    {
        [Required]
        public Guid PedidoId { get; set; }

        [Required]
        public int Codigo { get; set; }

        [Required]
        public Guid ProdutoId { get; set; }

        public Pedido Pedido { get; set; } = null;

        public Produto Produto { get; set; } = null;

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public double Preco { get; set; }

        public Domain.Pedido.ItemPedido ToDomain()
        {
            return new Domain.Pedido.ItemPedido()
            {
                Codigo = Codigo,
                Preco = Preco,
                Produto = Produto.ToDomain()
            };
        }

        public static ItemPedido ToSchema(Guid pedidoId, Domain.Pedido.ItemPedido item)
        {
            return new ItemPedido
            {
                Codigo = item.Codigo,
                Preco = item.Preco,
                PedidoId = pedidoId,
                ProdutoId = item.Produto.Id
            };
        }
    }
}
