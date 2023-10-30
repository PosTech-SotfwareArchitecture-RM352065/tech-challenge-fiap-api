using RestauranteSanduba.Core.Domain.Common.Assertions;
using RestauranteSanduba.Core.Domain.Common.Types;
using System;

namespace RestauranteSanduba.Core.Domain.Clientes.Abstractions
{
    public abstract class Cliente : Entity<Guid>
    {
        protected Cliente(Guid id) : base(id) { }

        public CPF CPF { get; init; }
        public AcessoCliente Tipo { get; init; }
        public string Nome { get; init; }
        public string Email { get; init; }

        public override void ValidateEntity()
        {
            AssertionConcern.AssertArgumentNotEmpty(Nome, "Nome inválido. Não deve ser vazio");
            AssertionConcern.AssertArgumentNotEmpty(Email, "E-mail inválido. Não deve ser vazio");
        }
    }
}
