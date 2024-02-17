using RestauranteSanduba.Core.Application.Abstraction.Cardapios;
using RestauranteSanduba.Core.Application.Abstraction.Cardapios.RequestModel;
using RestauranteSanduba.Core.Application.Abstraction.Cardapios.ResponseModel;
using RestauranteSanduba.Core.Domain.Cardapios;
using RestauranteSanduba.Core.Domain.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestauranteSanduba.Core.Application.Cardapios
{
    public class CardapioInteractor : ICardapioInteractor
    {
        private readonly ICardapioPersistenceGateway cardapioPersistenteceGateway;

        public CardapioInteractor(ICardapioPersistenceGateway cardapioPersistenceGateway)
        {
            this.cardapioPersistenteceGateway = cardapioPersistenceGateway;
        }

        public ConsultaProdutoResponse AtualizaProduto(AtualizaProdutoRequest requestModel)
        {
            var produtoExistente = cardapioPersistenteceGateway.ConsultarProduto(requestModel.Id);
            if (produtoExistente == null) throw new ProdutoInexistenteException(requestModel.Id);
            if (!produtoExistente.Ativo) throw new ProdutoInativoException(requestModel.Id);

            var produto = Produto.CriarProduto(requestModel.Id, requestModel.Categoria, requestModel.Nome, requestModel.Descricao, requestModel.Preco, true);
            produto.ValidateEntity();

            var produtoAtualizado = cardapioPersistenteceGateway.AtualizarProduto(produto);
            return new ConsultaProdutoResponse
            {
                Id = produtoAtualizado.Id,
                Categoria = produtoAtualizado.Categoria,
                Nome = produtoAtualizado.Nome,
                Descricao = produtoAtualizado.Descricao,
                Preco = produtoAtualizado.Preco,
                Ativo = produtoAtualizado.Ativo
            };
        }

        public CadastroProdutoResponse CadastrarProduto(CadastroProdutoRequest requestModel)
        {
            var produtoExistente = cardapioPersistenteceGateway.ConsultarProduto(requestModel.Nome);

            if (produtoExistente != null) throw new ProdutoDuplicadoException(produtoExistente.Id, produtoExistente.Nome);

            try
            {
                var categoria = (Categoria)Enum.Parse(typeof(Categoria), requestModel.Categoria);
                var produto = Produto.CriarProduto(Guid.NewGuid(), categoria, requestModel.Nome, requestModel.Descricao, requestModel.Preco, true);
                produto.ValidateEntity();

                cardapioPersistenteceGateway.CadastrarProduto(produto);

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

        public ConsultaProdutoResponse ConsultarProduto(ConsultaProdutoRequest requestModel)
        {
            var produto = cardapioPersistenteceGateway.ConsultarProduto(requestModel.Id);
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

        public List<ConsultaProdutoResponse> ConsultarProdutos(List<ConsultaProdutoRequest> requestModel)
        {
            var produtos = cardapioPersistenteceGateway.ConsultarProdutos(requestModel.Select(item => item.Id).ToList());
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
            var produtos = cardapioPersistenteceGateway.ConsultarProdutosAtivos();
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

        public ConsultaProdutoResponse InativarProduto(InativarProdutoRequest requestModel)
        {
            var produto = cardapioPersistenteceGateway.InativarProduto(requestModel.Id);
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
