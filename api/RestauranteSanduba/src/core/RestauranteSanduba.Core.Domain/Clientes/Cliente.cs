using RestauranteSanduba.Core.Common.Domain;
using System;

namespace RestauranteSanduba.Core.Domain.Clientes
{
    public abstract class Cliente : IAggregateRoot
    {
        public Guid Codigo { get; init; }
        public CPF? CPF { get; init; }
        public TipoCliente Tipo { get; init; }
        public string Nome { get; init; }
        public string Email { get; init; }

        public void ValidateEntity()
        {
            AssertionConcern.AsserArgumentNotEmpty(Nome, "Nome inválido. Não deve ser vazio");
            AssertionConcern.AsserArgumentNotEmpty(Email, "E-mail inválido. Não deve ser vazio");
        }
    }
}
