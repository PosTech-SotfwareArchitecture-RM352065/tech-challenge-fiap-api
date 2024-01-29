using Domain = RestauranteSanduba.Core.Domain.Pedidos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using RestauranteSanduba.Infra.PersistenceGateway.Clientes.Schema;

namespace RestauranteSanduba.Infra.PersistenceGateway.Pedidos.Schema
{
    public class Pedido
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
        public int Numero { get; set; }

        [Required]
        public Cliente Cliente { get; set; }

        [Required]
        public List<ItemPedido> Itens { get; set; }

        public Domain.Pedido ToDomain()
        {
            return Domain.Pedido.CriarPedido(Id, Cliente.ToDomain(), Numero);
        }

        public static Pedido ToSchema(Domain.Pedido pedido)
        {
            return new Pedido
            {
                Id = pedido.Id,
                Numero = (int)pedido.NumeroPedido,
                Cliente = Cliente.ToSchema(pedido.Cliente),
                Itens = pedido.Itens.Select(item => ItemPedido.ToSchema(item)).ToList()
            };
        }
    }
}
