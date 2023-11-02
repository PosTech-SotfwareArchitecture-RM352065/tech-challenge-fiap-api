using Domain = RestauranteSanduba.Core.Domain.Cardapios;
using System;
using System.Collections.Generic;
using System.Linq;
using RestauranteSanduba.Adapter.Driven.Infrastructure.Cardapios.Schema;
using RestauranteSanduba.Core.Application.Cardapios.Abstractions;

namespace RestauranteSanduba.Adapter.Driven.Infrastructure.Cardapios
{
    public class CardapioRepository : ICardapioRepository
    {
        private readonly InfrastructureDbContext _dbContext;

        public CardapioRepository(InfrastructureDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void CadastrarProduto(Domain.Produto produto)
        {
            _dbContext.Produtos.Add(Produto.ToSchema(produto));
            _dbContext.SaveChanges();
        }

        public Domain.Produto ConsultarProduto(Guid id)
        {
            return _dbContext.Produtos
                .Where(item => item.Id == id)
                .Select(item => item.ToDomain())
                .FirstOrDefault();
        }

        public List<Domain.Produto> ConsultarProdutosAtivos()
        {
            return _dbContext.Produtos
                .Where(item => item.Ativo)
                .Select(item => item.ToDomain())
                .ToList();
        }

        public List<Domain.Produto> ConsultarProdutos(List<Guid> ids)
        {
            return _dbContext.Produtos
                .Where(item => ids.Contains(item.Id))
                .Select(item => item.ToDomain())
                .ToList();
        }

        public void InativarProduto(Domain.Produto produto)
        {
            var produtoInativo = ConsultarProduto(produto.Id);
            produtoInativo.InativarProduto();

            _dbContext.Produtos.Update(Produto.ToSchema(produtoInativo));
            _dbContext.SaveChanges();
        }
    }
}
