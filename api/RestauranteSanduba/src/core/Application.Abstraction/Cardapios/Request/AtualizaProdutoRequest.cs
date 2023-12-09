using RestauranteSanduba.Core.Domain.Cardapios;
using System;

namespace RestauranteSanduba.Core.Application.Abstraction.Cardapios.Request
{
    public record AtualizaProdutoRequest (Guid Id, Categoria Categoria, string Nome, string Descricao, double Preco, bool Ativo);
    //{
    //    public Guid Id { get; set; }
    //    public Categoria categoria { get; set; }
    //    public string Nome { get; set; }
    //    public string Descricao { get; set; }
    //    public double Preco { get; set; }
    //    public bool Ativo { get; set; }
    //}
}
