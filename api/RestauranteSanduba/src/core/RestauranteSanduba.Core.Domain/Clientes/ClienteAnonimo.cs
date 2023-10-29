using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteSanduba.Core.Domain.Clientes
{
    public class ClienteAnonimo : Cliente
    {
        public static Cliente CriarCliente()
        {
            var cliente = new ClienteAnonimo()
            {
                Codigo = new Guid(),
                CPF = null,
                Tipo = TipoCliente.Anonimo,
                Nome = "Cliente Anônimo",
                Email = "anonimo@mail.com"
            };

            return cliente;
        }
    }
}
