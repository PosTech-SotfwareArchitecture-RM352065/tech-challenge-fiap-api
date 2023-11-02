using RestauranteSanduba.Core.Domain.Cardapios;
using RestauranteSanduba.Core.Domain.Clientes;
using RestauranteSanduba.Core.Domain.Pedidos;
using System;
using Xunit;

namespace RestauranteSanduba.Test.Core.DomainTest.core.domain.Pedidos;

public class PedidoTest
{
    [Fact]
    public void DadoLancheAdicionadoPedidoDeveConterProduto()
    {
        var cliente = ClienteAnonimo.CriarCliente(Guid.NewGuid());
        var numeroPedido = 1000;

        var pedido = Pedido.CriarPedido(Guid.NewGuid(), cliente, numeroPedido);

        var categoriaLanche = Categoria.Lanche;
        var nomeLanche = "X-Tudo";
        var descricaoLanche = "Lanche com todos ingredientes";
        var precoLanche = 30.10;

        var lanche = Produto.CriarProduto(Guid.NewGuid(), categoriaLanche, nomeLanche, descricaoLanche, precoLanche, true);

        pedido.AdicionaProduto(lanche);

        Assert.NotEmpty(pedido.Itens);
        Assert.Single(pedido.Itens);

        var lanchePedido = new Pedido.ItemPedido()
        {
            Codigo = 1,
            Preco = precoLanche,
            Produto = lanche
        };

        Assert.Contains(lanchePedido, pedido.Itens);

    }

    [Fact]
    public void DadoItensAdicionadosPedidoDeveRetornarTotal()
    {
        var cliente = ClienteAnonimo.CriarCliente(Guid.NewGuid());
        var numeroPedido = 1000;

        var pedido = Pedido.CriarPedido(Guid.NewGuid(), cliente, numeroPedido);

        var categoriaLanche = Categoria.Lanche;
        var nomeLanche = "X-Tudo";
        var descricaoLanche = "Lanche com todos ingredientes";
        var precoLanche = 30.10;

        var lanche = Produto.CriarProduto(Guid.NewGuid(), categoriaLanche, nomeLanche, descricaoLanche, precoLanche, true);

        pedido.AdicionaProduto(lanche);

        var categoriaAcompanhamento = Categoria.Acompanhamento;
        var nomeAcompanhamento = "X-Tudo";
        var descricaoAcompanhamento = "Lanche com todos ingredientes";
        var precoAcompanmhamento = 11.25;

        var acompanhamento = Produto.CriarProduto(Guid.NewGuid(), categoriaAcompanhamento, nomeAcompanhamento, descricaoAcompanhamento, precoAcompanmhamento, true);

        pedido.AdicionaProduto(acompanhamento);

        Assert.NotEmpty(pedido.Itens);
        Assert.Equal(2, pedido.Itens.Count);
        Assert.Equal(41.35, pedido.ObtemTotal());
    }
}