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

        [Required(ErrorMessage = "Nome obrigatórioo")]
        [Display(Name = "Nome Fantasia")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "CNPJ obrigatórioo")]
        [Display(Name="CNPJ")]
        [StringLength(12)]
        public string Cnpj { get; set; }

        [Required(ErrorMessage = "e-mail obrigatório")]
        [Display(Name = "E-mail")]
        [StringLength(12)]
        public string email { get; set; }

        [Required(ErrorMessage = "Telefone obrigatório")]
        [Display(Name = "Telefone")]
        [StringLength(11)]
        public string Telefone { get; set; }

        [Display(Name = "Telefone-Adicional")]
        [StringLength(11)]
        public string TelefoneDois { get; set; }
        public List<Equipamento> Equipamentos { get; set; }

        public List<Endereco> Enderecos { get; set; } 

    }
}
