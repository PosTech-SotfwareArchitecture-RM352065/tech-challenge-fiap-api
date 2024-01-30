﻿using Microsoft.EntityFrameworkCore;
using Domain = RestauranteSanduba.Core.Domain.Pedidos;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using RestauranteSanduba.Infra.PersistenceGateway.Cardapios.Schema;
using System.ComponentModel.DataAnnotations;

namespace RestauranteSanduba.Infra.PersistenceGateway.Pedidos.Schema
{
    [PrimaryKey(nameof(Id))]
    public class ItemPedido
    {
        [Required] 
        public Guid Id { get; set; }
        [Required] 
        public int Codigo { get; set; }
        [Required]
        public Guid PedidoId { get; set; }
        public Pedido Pedido { get; set; } = null;
        [Required]
        public Guid ProdutoId { get; set; }
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
                Produto = Produto.ToDomain(),
            };
        }

        public static ItemPedido ToSchema(Domain.Pedido.ItemPedido item)
        {
            return new ItemPedido
            {
                Codigo = item.Codigo,
                Preco = item.Preco,
                ProdutoId = item.Produto.Id
            };
        }
    }
}
