using Domain = RestauranteSanduba.Core.Domain.Cardapios;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestauranteSanduba.Adapter.Driven.Infrastructure.Cardapios.Schema
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
            return Domain.Produto.CriarProduto(this.Id, (Domain.Categoria)this.Categoria, this.Nome, this.Descricao, this.Preco, this.Ativo);
        }

        public static Schema.Produto ToSchema(Domain.Produto produto)
        {
            return new Schema.Produto 
            { 
                Preco = produto.Preco,
                Id  = produto.Id,
                Nome = produto.Nome,
                Categoria = (int)produto.Categoria,
                Descricao = produto.Descricao,
                Ativo = produto.Ativo
            };
        }
    }
}
