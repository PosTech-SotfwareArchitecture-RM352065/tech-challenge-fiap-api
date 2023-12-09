using RestauranteSanduba.Core.Domain.Cardapios;
using System;

namespace RestauranteSanduba.Core.Application.Abstraction.Cardapios.Response
{
    public record ConsultaProdutoResponse
    {
        public Guid Id { get; set; }
        public Categoria Categoria { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public double Preco { get; set; }
        public bool Ativo { get; set; }
    }
}
