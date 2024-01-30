using Domain = RestauranteSanduba.Core.Domain.Pedidos;
using System;
using System.Collections.Generic;
using System.Linq;
using RestauranteSanduba.Infra.PersistenceGateway.Clientes.Schema;
using System.ComponentModel.DataAnnotations;

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
        public Guid ClienteId { get; set; }

        public DateTime CriadoEm { get; set; }
        [Required] 
        public int Status { get; set; }

        public Cliente Cliente { get; set; } = null;
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
                ClienteId = pedido.Cliente.Id,
                Status = (int)pedido.Status,
                Itens = pedido.Itens.Select(item => ItemPedido.ToSchema(item)).ToList()
            };
        }
    }
}
