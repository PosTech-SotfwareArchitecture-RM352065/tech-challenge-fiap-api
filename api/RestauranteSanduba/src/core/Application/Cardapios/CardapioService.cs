using MediatR;
using RestauranteSanduba.Core.Application.Abstraction.Cardapios;
using RestauranteSanduba.Core.Application.Abstraction.Cardapios.Request;
using RestauranteSanduba.Core.Application.Abstraction.Cardapios.Response;
using RestauranteSanduba.Core.Domain.Cardapios;
using RestauranteSanduba.Core.Domain.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteSanduba.Core.Application.Cardapios
{
    public class CardapioService : ICardapioService
    {
        private readonly ICardapioRepository _cardapioRepository;

        public CardapioService(ICardapioRepository cardapioRepository)
        {
            _cardapioRepository = cardapioRepository;
        }

        public ConsultaProdutoResponse AtualizaPrecoProduto(AtualizaProdutoRequest request)
        {
            throw new NotImplementedException();
        }

        public CadastroProdutoResponse CadastrarProduto(CadastroProdutoRequest request)
        {
            var produtoExistente = _cardapioRepository.ConsultarProduto(request.Nome);

            if(produtoExistente != null) throw new ProdutoDuplicadoException(produtoExistente.Id, produtoExistente.Nome);

            try
            {
                var produto = Produto.CriarProduto(Guid.NewGuid(), request.categoria, request.Nome, request.Descricao, request.Preco, true);
                produto.ValidateEntity();

                _cardapioRepository.CadastrarProduto(produto);

                return new CadastroProdutoResponse
                {
                    Id = produto.Id
                };
            }
            catch (DomainException ex) 
            {
                throw new ProdutoDomainException(ex);
            }
        }

        public ConsultaProdutoResponse ConsultarProduto(ConsultaProdutoRequest request)
        {
            var produto = _cardapioRepository.ConsultarProduto(request.Id);
            return new ConsultaProdutoResponse
            {
                Id = produto.Id,
                Categoria = produto.Categoria,
                Nome = produto.Nome,
                Descricao = produto.Descricao,
                Preco = produto.Preco,
                Ativo = produto.Ativo
            };
        }

        public List<ConsultaProdutoResponse> ConsultarProdutos(List<ConsultaProdutoRequest> request)
        {
            var produtos = _cardapioRepository.ConsultarProdutos(request.Select(item => item.Id).ToList());
            return produtos.Select(produto =>
                new ConsultaProdutoResponse
                {
                    Id = produto.Id,
                    Categoria = produto.Categoria,
                    Nome = produto.Nome,
                    Descricao = produto.Descricao,
                    Preco = produto.Preco,
                    Ativo = produto.Ativo
                }).ToList();
        }

        public List<ConsultaProdutoResponse> ConsultarProdutosAtivos()
        {
            var produtos = _cardapioRepository.ConsultarProdutosAtivos();
            return produtos.Select(produto =>
                new ConsultaProdutoResponse
                {
                    Id = produto.Id,
                    Categoria = produto.Categoria,
                    Nome = produto.Nome,
                    Descricao = produto.Descricao,
                    Preco = produto.Preco,
                    Ativo = produto.Ativo
                }).ToList();
        }

        public ConsultaProdutoResponse InativarProduto(AtualizaProdutoRequest request)
        {
            var produto = Produto.CriarProduto(Guid.NewGuid(), request.Categoria, request.Nome, request.Descricao, request.Preco, false);
            _cardapioRepository.InativarProduto(produto);

            return new ConsultaProdutoResponse
            {
                Id = produto.Id,
                Categoria = produto.Categoria,
                Nome = produto.Nome,
                Descricao = produto.Descricao,
                Preco = produto.Preco,
                Ativo = produto.Ativo
            };
        }
    }
}
