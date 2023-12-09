using Microsoft.EntityFrameworkCore;
using Domain = RestauranteSanduba.Core.Domain.Pedidos;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RestauranteSanduba.Adapter.Driven.Persistence.Cardapios.Schema;

namespace RestauranteSanduba.Adapter.Driven.Persistence.Pedidos.Schema
{
    [PrimaryKey(nameof(Id))]
    public class ItemPedido
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public int Codigo { get; set; }

        [Required]
        public Produto Produto { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public double Preco { get; set; }

        internal Domain.Pedido.ItemPedido ToDomain()
        {
            return new Domain.Pedido.ItemPedido()
            {
                Codigo = Codigo,
                Preco = Preco,
                Produto = Produto.ToDomain(),
            };
        }

        internal static ItemPedido ToSchema(Domain.Pedido.ItemPedido item)
        {
            return new ItemPedido
            {
                Codigo = item.Codigo,
                Preco = item.Preco,
                Produto = Produto.ToSchema(item.Produto)
            };
        }
    }
}
