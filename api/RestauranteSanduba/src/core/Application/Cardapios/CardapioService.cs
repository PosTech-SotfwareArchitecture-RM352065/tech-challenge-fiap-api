using MediatR;
using RestauranteSanduba.Core.Application.Cardapios.Abstractions;
using RestauranteSanduba.Core.Application.Cardapios.Abstractions.Request;
using RestauranteSanduba.Core.Application.Cardapios.Abstractions.Response;
using RestauranteSanduba.Core.Domain.Cardapios;
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
            var produto = Produto.CriarProduto(Guid.NewGuid(), request.categoria, request.Nome, request.Descricao, request.Preco, true);
            _cardapioRepository.CadastrarProduto(produto);

            return new CadastroProdutoResponse
            {
                Id = produto.Id
            };
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
            var produto = Produto.CriarProduto(Guid.NewGuid(), request.categoria, request.Nome, request.Descricao, request.Preco, false);
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
