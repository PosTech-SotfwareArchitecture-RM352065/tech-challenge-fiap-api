using Domain = RestauranteSanduba.Core.Domain.Cardapios;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestauranteSanduba.Infra.PersistenceGateway.Cardapios.Schema
{
    public class Produto
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50)]
        [Column(TypeName = "varchar(50)")]
        public string Nome { get; set; }

        [Required]
        [MaxLength(50)]
        [Column(TypeName = "varchar(50)")]
        public string Descricao { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public double Preco { get; set; }

        [Required]
        public int Categoria { get; set; }

        [Required]
        public bool Ativo { get; set; }

        public Domain.Produto ToDomain()
        {
            return Domain.Produto.CriarProduto(Id, (Domain.Categoria)Categoria, Nome, Descricao, Preco, Ativo);
        }

        public static Produto ToSchema(Domain.Produto produto)
        {
            return new Produto
            {
                Preco = produto.Preco,
                Id = produto.Id,
                Nome = produto.Nome,
                Categoria = (int)produto.Categoria,
                Descricao = produto.Descricao,
                Ativo = produto.Ativo
            };
        }
    }
}
