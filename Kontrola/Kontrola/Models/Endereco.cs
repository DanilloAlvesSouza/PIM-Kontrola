using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kontrola.Models
{
    [Table("Enderecos")]
    public class Endereco
    {
        [Key]
        public  int EnderecoId { get; set; }
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [Column(TypeName ="decimal(8)")]
        public decimal Cep { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Bairro { get; set; }

        [Required(ErrorMessage ="Campo Obrigatório")]
        public string Cidade { get; set; }

        [StringLength(2)]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string UF{ get; set; }

        public int ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }
    }
}
