using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestauranteSanduba.Core.Domain.Clientes.Abstractions;

namespace RestauranteSanduba.Core.Domain.Clientes
{
    public sealed class ClienteAnonimo : Cliente
    {
        private ClienteAnonimo(Guid id) : base(id) { }

        public static Cliente CriarCliente()
        {
            var cliente = new ClienteAnonimo(Guid.NewGuid())
            {
                CPF = null,
                Tipo = AcessoCliente.Anonimo,
                Nome = "Cliente Anônimo",
                Email = "anonimo@mail.com"
            };

            cliente.ValidateEntity();

            return cliente;
        }
    }
}
