using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace KontrolaPoc.Models
{
    [Table("Cliente")]
    public class Cliente
    {
        [Key]
        public int ClienteId { get; set; }

        [Required(ErrorMessage ="O nome do cliente deve ser informado")]
        [Display(Name = "Nome Fantasia")]
        public string Nome { get; set; }

        [Required(ErrorMessage ="CNPJ do cliente deve ser informado")]
        [Display(Name="CNPJ")]
        [StringLength(12)]
        public string Cnpj { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [StringLength(9)]
        [Display(Name = "CEP")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Cidade { get; set; }

        [StringLength(2)]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string UF { get; set; }
        public List<Equipamento> Equipamentos { get; set; }

        public List<Endereco> Enderecos { get; set; } 

    }
}
