﻿using RestauranteSanduba.Core.Domain.Clientes;
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
            var id = Guid.NewGuid();
            var nome = "Joao Silva";
            var cpfFormatado = "000.000.000-00";
            var cpfSemFormatacao = "00000000000";
            var email = "joao.silva@mail.com";
            var senha = "SenhaForte1!";

            var cliente = ClienteIdentificado.CriarCliente(id, cpfFormatado, nome, email, senha);

            Assert.NotNull(cliente);
            Assert.Equal(cpfSemFormatacao, cliente.CPF?.ToString());
            Assert.Equal(AcessoCliente.Identificado, cliente.Tipo);
            Assert.Equal(nome, cliente.Nome);
            Assert.Equal(email, cliente.Email);
        }

        [Fact]
        public void DadoCPFInvalidoDeveRetornarErro()
        {
            var id = Guid.NewGuid();
            var nome = "Joao Silva";
            var cpfFormatado = "111.222.333-00";
            var email = "joao.silva@mail.com";
            var senha = "SenhaForte1!";

            Assert.Throws<DomainException>(() =>
            {
                ClienteIdentificado.CriarCliente(id, cpfFormatado, nome, email, senha);
            });
        }

        [Fact]
        public void DadoCPFVazioDeveRetornarErro()
        {
            var id = Guid.NewGuid();
            var nome = "Joao Silva";
            var cpfFormatado = string.Empty;
            var email = "joao.silva@mail.com";
            var senha = "SenhaForte1!";

            Assert.Throws<DomainException>(() =>
            {
                ClienteIdentificado.CriarCliente(id, cpfFormatado, nome, email, senha);
            });
        }

        [Fact]
        public void DadoClienteAnonimoDeveRetornarCliente()
        {
            var id = Guid.NewGuid();
            var nome = "Cliente Anônimo";
            var email = "anonimo@mail.com";

            var cliente = ClienteAnonimo.CriarCliente(id);

            Assert.NotNull(cliente);
            Assert.Null(cliente.CPF);
            Assert.Equal(AcessoCliente.Anonimo, cliente.Tipo);
            Assert.Equal(nome, cliente.Nome);
            Assert.Equal(email, cliente.Email);
        }

        [Fact]
        public void DadoNomeVazioDeveRetornarErro()
        {
            var id = Guid.NewGuid();
            var nome = string.Empty;
            var cpfFormatado = "000.000.000-00";
            var email = "joao.silva@mail.com";
            var senha = "SenhaForte1!";

            Assert.Throws<DomainException>(() =>
            {
                ClienteIdentificado.CriarCliente(id, cpfFormatado, nome, email, senha);
            });
        }

        [Fact]
        public void DadoEmailVazioDeveRetornarErro()
        {
            var id = Guid.NewGuid();
            var nome = "Joao Silva";
            var cpfFormatado = "000.000.000-00";
            var email = string.Empty;
            var senha = "SenhaForte1!";

            Assert.Throws<DomainException>(() =>
            {
                ClienteIdentificado.CriarCliente(id, cpfFormatado, nome, email, senha);
            });
        }
    }
}
