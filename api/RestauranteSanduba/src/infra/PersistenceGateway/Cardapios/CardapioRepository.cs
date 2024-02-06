using Domain = RestauranteSanduba.Core.Domain.Cardapios;
using System;
using System.Collections.Generic;
using System.Linq;
using RestauranteSanduba.Core.Application.Abstraction.Cardapios;
using RestauranteSanduba.Infra.PersistenceGateway.Cardapios.Schema;
using RestauranteSanduba.Infra.PersistenceGateway;

namespace RestauranteSanduba.Infra.PersistenceGateway.Cardapios
{
    public class CardapioRepository : ICardapioPersistenceGateway
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

        public Domain.Produto ConsultarProduto(string nome)
        {
            return _dbContext.Produtos
                .Where(item => item.Nome == nome)
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

        public Domain.Produto InativarProduto(Guid id)
        {
            var produto = ConsultarProduto(id);
            produto.InativarProduto();

            _dbContext.Produtos.Update(Produto.ToSchema(produto));
            _dbContext.SaveChanges();

            return produto;
        }

        public Domain.Produto AtualizarProduto(Domain.Produto produto)
        {
            var produtoEntity = _dbContext.Produtos.Update(Produto.ToSchema(produto));
            _dbContext.SaveChanges();

            return produtoEntity.Entity.ToDomain();
        }
    }
}
