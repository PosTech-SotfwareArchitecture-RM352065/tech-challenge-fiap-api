using RestauranteSanduba.Core.Domain.Clientes;
using RestauranteSanduba.Core.Domain.Common.Exceptions;
using System;
using Xunit;

namespace RestauranteSanduba.Test.Core.DomainTest.core.domain.Clientes
{
    public class ClienteTest
    {
        [Fact]
        public void DadoClienteValidoDeveRetornarCliente()
        {
            var nome = "Joao Silva";
            var cpfFormatado = "000.000.000-00";
            var cpfSemFormatacao = "00000000000";
            var email = "joao.silva@mail.com";

            var cliente = ClienteIdentificado.CriarCliente(cpfFormatado, nome, email);

            Assert.NotNull(cliente);
            Assert.Equal(cpfSemFormatacao, cliente.CPF?.ToString());
            Assert.Equal(AcessoCliente.Identificado, cliente.Tipo);
            Assert.Equal(nome, cliente.Nome);
            Assert.Equal(email, cliente.Email);
        }

        [Fact]
        public void DadoCPFInvalidoDeveRetornarErro()
        {
            var nome = "Joao Silva";
            var cpfFormatado = "111.222.333-00";
            var email = "joao.silva@mail.com";

            Assert.Throws<DomainException>(() =>
            {
                var cliente = ClienteIdentificado.CriarCliente(cpfFormatado, nome, email);
            });
        }

        [Fact]
        public void DadoCPFVazioDeveRetornarErro()
        {
            var nome = "Joao Silva";
            var cpfFormatado = string.Empty;
            var email = "joao.silva@mail.com";

            Assert.Throws<DomainException>(() =>
            {
                var cliente = ClienteIdentificado.CriarCliente(cpfFormatado, nome, email);
            });
        }

        [Fact]
        public void DadoClienteAnonimoDeveRetornarCliente()
        {
            var nome = "Cliente Anônimo";
            var email = "anonimo@mail.com";

            var cliente = ClienteAnonimo.CriarCliente();

            Assert.NotNull(cliente);
            Assert.Null(cliente.CPF);
            Assert.Equal(AcessoCliente.Anonimo, cliente.Tipo);
            Assert.Equal(nome, cliente.Nome);
            Assert.Equal(email, cliente.Email);
        }

        [Fact]
        public void DadoNomeVazioDeveRetornarErro()
        {
            var nome = string.Empty;
            var cpfFormatado = "000.000.000-00";
            var email = "joao.silva@mail.com";

            Assert.Throws<ArgumentException>(() =>
            {
                var cliente = ClienteIdentificado.CriarCliente(cpfFormatado, nome, email);
            });
        }

        [Fact]
        public void DadoEmailVazioDeveRetornarErro()
        {
            var nome = "Joao Silva";
            var cpfFormatado = "000.000.000-00";
            var email = string.Empty;

            Assert.Throws<ArgumentException>(() =>
            {
                var cliente = ClienteIdentificado.CriarCliente(cpfFormatado, nome, email);
            });
        }
    }
}
