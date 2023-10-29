using RestauranteSanduba.Core.Domain.Cardapios;
using RestauranteSanduba.Core.Domain.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestauranteSanduba.Core.Domain.Pedidos
{
    public class Pedido
    {
        public record ItemPedido
        {
            public int Codigo { get; init; }
            public Produto Produto { get; init; }
            public double Preco { get; init; }
        }

        public int NumeroPedido { get; init; }

        public List<ItemPedido> Itens { get; private set; } = new List<ItemPedido>();

        public Cliente Cliente { get; init; }

        public static Pedido CriarPedido(int numeroPedido, Cliente cliente)
        {
            var pedido = new Pedido()
            {
                NumeroPedido = numeroPedido,
                Cliente = cliente
            };

            return pedido;
        }

        public void AdicionaProduto(Produto produto)
        {
            var item = new ItemPedido()
            {
                Codigo = Itens.Count + 1,
                Produto = produto,
                Preco = produto.Preco
            };

            Itens.Add(item);
        }

        public ItemPedido RemoveItem(int codigo)
        {
            var item = Itens.FirstOrDefault(item => item.Codigo == codigo);
            if (item is null) throw new Exception($"Item de código {codigo} não encontrado!");

            if (Itens.Remove(item)) return item;
            else throw new Exception($"Não foi possível remover o item de código {codigo}");
        }

        public double ObtemTotal()
        {
            return Itens.Sum(item => item.Preco);
        }
    }
}
