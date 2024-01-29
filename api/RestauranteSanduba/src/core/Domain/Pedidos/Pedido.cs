using RestauranteSanduba.Core.Domain.Cardapios;
using RestauranteSanduba.Core.Domain.Clientes.Abstractions;
using RestauranteSanduba.Core.Domain.Common.Assertions;
using RestauranteSanduba.Core.Domain.Common.Exceptions;
using RestauranteSanduba.Core.Domain.Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestauranteSanduba.Core.Domain.Pedidos
{
    public sealed class Pedido : Entity<Guid>
    {
        public class ItemPedido : ValueObject
        {
            public int Codigo { get; init; }
            public Produto Produto { get; init; }
            public double Preco { get; init; }

            protected override IEnumerable<object> GetEqualityComponents()
            {
                yield return Codigo;
            }
        }

        public int? NumeroPedido { get; init; }

        private Pedido(Guid id) : base(id) { }

        private readonly List<ItemPedido> _itens = new();

        public IReadOnlyCollection<ItemPedido> Itens => _itens;

        public Cliente Cliente { get; init; }

        public StatusPedido Status { get; private set; }

        public static Pedido CriarPedido(Guid id, Cliente cliente, int? numeroPedido = null)
        {
            var pedido = new Pedido(id)
            {
                NumeroPedido = numeroPedido,
                Cliente = cliente,
                Status = StatusPedido.Recebido
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

            _itens.Add(item);
        }

        public void InciaPreparo()
        {
            AssertionConcern.AssertArgumentEqual(Status, StatusPedido.Recebido, "Pedido deve estar com status de RECEBIDO");

            Status = StatusPedido.EmPreparacao;
        }

        public void CancelaPedido()
        {
            AssertionConcern.AssertArgumentEqual(Status, StatusPedido.Recebido, "Pedido deve estar com status de RECEBIDO");

            Status = StatusPedido.Cancelado;
        }

        public void PreparoFinalizado()
        {
            AssertionConcern.AssertArgumentEqual(Status, StatusPedido.EmPreparacao, "Pedido deve estar com status de EM PREPARAÇÃO");

            Status = StatusPedido.Pronto;
        }

        public void Retirado()
        {
            AssertionConcern.AssertArgumentEqual(Status, StatusPedido.Pronto, "Pedido deve estar com status de PRONTO");

            Status = StatusPedido.Finalizado;
        }

        public void AdicionaProdutos(List<Produto> produtos)
        {
            var itens = produtos.Select(produto =>
                new ItemPedido()
                {
                    Codigo = Itens.Count + 1,
                    Produto = produto,
                    Preco = produto.Preco
                });


            _itens.AddRange(itens);
        }

        public ItemPedido RemoveItem(int codigo)
        {
            var item = _itens.FirstOrDefault(item => item.Codigo == codigo);
            if (item is null) throw new DomainException($"Item de código {codigo} não encontrado!");

            if (_itens.Remove(item)) return item;
            else throw new DomainException($"Não foi possível remover o item de código {codigo}");
        }

        public double ObtemTotal()
        {
            return Itens.Sum(item => item.Preco);
        }

        public override void ValidateEntity()
        {
            AssertionConcern.AssertArgumentNotEmpty(_itens, "Pedido não pode estar vazio");
            Cliente.ValidateEntity();
        }
    }
}
