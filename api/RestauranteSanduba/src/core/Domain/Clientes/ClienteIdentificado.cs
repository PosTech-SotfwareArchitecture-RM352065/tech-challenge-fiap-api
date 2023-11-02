using System;
using RestauranteSanduba.Core.Domain.Clientes.Abstractions;

namespace RestauranteSanduba.Core.Domain.Clientes
{
    public sealed class ClienteIdentificado : Cliente
    {
        private ClienteIdentificado(Guid id) : base(id) { }

        public static Cliente CriarCliente(Guid id, string numeroDocumento, string nome, string email)
        {
            CPF cpf = new CPF(numeroDocumento);
            var cliente = new ClienteIdentificado(id)
            {
                CPF = cpf,
                Tipo = AcessoCliente.Identificado,
                Nome = nome,
                Email = email
            };

            cliente.ValidateEntity();

            return cliente;
        }
    }
}
