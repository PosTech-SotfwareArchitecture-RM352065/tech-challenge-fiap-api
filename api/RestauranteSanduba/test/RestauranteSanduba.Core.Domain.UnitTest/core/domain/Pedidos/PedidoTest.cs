using RestauranteSanduba.Core.Domain.Cardapios;
using RestauranteSanduba.Core.Domain.Clientes;
using RestauranteSanduba.Core.Domain.Pedidos;
using Xunit;

namespace RestauranteSanduba.UnitTest;

public class PedidoTest
{
    [Fact]
    public void DadoLancheAdicionadoPedidoDeveConterProduto()
    {
        var cliente = ClienteAnonimo.CriarCliente();
        var numeroPedido = 1000;

        var pedido = Pedido.CriarPedido(numeroPedido: numeroPedido, cliente: cliente);

        var categoriaLanche = Categoria.Lanche;
        var nomeLanche = "X-Tudo";
        var descricaoLanche = "Lanche com todos ingredientes";
        var precoLanche = 30.10;

        var lanche = Produto.CriarProduto(categoriaLanche, nomeLanche, descricaoLanche, precoLanche);

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
        var cliente = ClienteAnonimo.CriarCliente();
        var numeroPedido = 1000;

        var pedido = Pedido.CriarPedido(numeroPedido: numeroPedido, cliente: cliente);

        var categoriaLanche = Categoria.Lanche;
        var nomeLanche = "X-Tudo";
        var descricaoLanche = "Lanche com todos ingredientes";
        var precoLanche = 30.10;

        var lanche = Produto.CriarProduto(categoriaLanche, nomeLanche, descricaoLanche, precoLanche);

        pedido.AdicionaProduto(lanche);

        var categoriaAcompanhamento = Categoria.Acompanhamento;
        var nomeAcompanhamento = "X-Tudo";
        var descricaoAcompanhamento = "Lanche com todos ingredientes";
        var precoAcompanmhament0 = 11.25;

        var acompanhamento = Produto.CriarProduto(categoriaAcompanhamento, nomeAcompanhamento, descricaoAcompanhamento, precoAcompanmhament0);

        pedido.AdicionaProduto(acompanhamento);

        Assert.NotEmpty(pedido.Itens);
        Assert.Equal(2, pedido.Itens.Count);
        Assert.Equal(41.35, pedido.ObtemTotal());
    }
}