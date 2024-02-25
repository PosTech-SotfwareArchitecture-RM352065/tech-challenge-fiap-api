using Domain = RestauranteSanduba.Core.Domain.Clientes.Abstractions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestauranteSanduba.Infra.PersistenceGateway.SqlServer.Clientes.Schema
{
    public class Cliente
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(11)]
        [Column(TypeName = "varchar(11)")]
        public string CPF { get; set; }

        [Required]
        public int Tipo { get; set; }

        [Required]
        [MaxLength(50)]
        [Column(TypeName = "varchar(50)")]
        public string Nome { get; set; }

        [Required]
        [MaxLength(50)]
        [Column(TypeName = "varchar(50)")]
        public string Email { get; init; }

        public Domain.Cliente ToDomain()
        {
            if (Tipo == 0)
            {
                return Core.Domain.Clientes.ClienteIdentificado.CriarCliente(Id, CPF, Nome, Email);
            }
            else
            {
                return Core.Domain.Clientes.ClienteAnonimo.CriarCliente(Id);
            }
        }

        public static Cliente ToSchema(Domain.Cliente cliente)
        {
            return new Cliente
            {
                Id = cliente.Id,
                CPF = cliente.CPF.ToString(),
                Email = cliente.Email,
                Nome = cliente.Nome,
                Tipo = (int)cliente.Tipo
            };
        }
    }
}
