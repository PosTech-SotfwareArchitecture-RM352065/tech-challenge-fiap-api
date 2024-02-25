using RestauranteSanduba.Core.Domain.Common.Exceptions;
using System;
using ApplicationException = RestauranteSanduba.Core.Application.Abstraction.Exceptions.ApplicationException;

namespace RestauranteSanduba.Core.Application.Cardapios
{
    public class CardapioException : ApplicationException
    {
        private CardapioException() : base() { }
        public CardapioException(string message) : base(message) { }
        public CardapioException(string message, Exception innerException) : base(message, innerException) { }
    }

    public class ProdutoDuplicadoException : CardapioException
    {
        public readonly Guid CodigoExistente;
        public readonly string NomeExistente;
        public ProdutoDuplicadoException(Guid id, string nome)
            : base($"Produto duplicado! Id {id} Nome {nome}.")
        {
            CodigoExistente = id;
            NomeExistente = nome;
        }
    }

    public class ProdutoInexistenteException : CardapioException
    {
        public readonly Guid Codigo;
        public ProdutoInexistenteException(Guid id)
            : base($"Produto inexistente! Id {id}.")
        {
            Codigo = id;
        }
    }

    public class ProdutoInativoException : CardapioException
    {
        public readonly Guid Codigo;
        public ProdutoInativoException(Guid id)
            : base($"Produto inativo! Id {id}.")
        {
            Codigo = id;
        }
    }

    public class ProdutoDomainException : CardapioException
    {
        public readonly DomainException domainException;
        public ProdutoDomainException(DomainException exception)
            : base($"Produto Inválido! {exception.Message}", exception)
        {
            domainException = exception;
        }
    }
}
