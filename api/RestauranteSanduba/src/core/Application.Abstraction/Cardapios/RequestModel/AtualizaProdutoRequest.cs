using RestauranteSanduba.Core.Domain.Cardapios;
using System;

namespace RestauranteSanduba.Core.Application.Abstraction.Cardapios.RequestModel
{
    public record AtualizaProdutoRequest(Guid Id, Categoria Categoria, string Nome, string Descricao, double Preco, bool Ativo);
}
