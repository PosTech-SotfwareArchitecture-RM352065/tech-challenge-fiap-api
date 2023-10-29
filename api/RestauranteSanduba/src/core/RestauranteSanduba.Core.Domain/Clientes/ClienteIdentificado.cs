using System;

namespace RestauranteSanduba.Core.Domain.Clientes
{
    public class ClienteIdentificado : Cliente
    {
        public static Cliente CriarCliente(string numeroDocumento, string nome, string email)
        {
            if (string.IsNullOrEmpty(nome)) throw new ArgumentException("Nome inválido", nameof(nome));
            if (string.IsNullOrEmpty(email)) throw new ArgumentException("E-mail inválido", nameof(email));

            CPF cpf = new CPF(numeroDocumento);
            var cliente = new ClienteIdentificado()
            {
                Codigo = Guid.NewGuid(),
                CPF = cpf,
                Tipo = TipoCliente.Identificado,
                Nome = nome,
                Email = email
            };

            return cliente;
        }
    }
}
