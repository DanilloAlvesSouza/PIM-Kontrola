using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KontrolaPoc.Models
{
    [Table("Chamados")]
    public class Chamado
    {
        [Key]
        public int ChamadoId { get; set; }

        [Required(ErrorMessage ="Obrigatorio Escolher a data de inicio do chamado")]
        public DateTime DataInicio { get; set; }

        [Required(ErrorMessage = "Obrigatorio Escolher a data de fechamento do chamado")]
        public DateTime DataFechamento { get; set; }

        [Required(ErrorMessage = "Informe a descrição")]
        public string Descricao{ get; set; }

        public string  Diagnostico { get; set; }

        public string Pendencia { get; set; }

        public string Conclusao { get; set; }

        public List<ItemChamado> ItemChamados { get; set; }
        public int StatusId { get; set; }
        public virtual Status Status { get; set; }

        public int ModalidadeId { get; set; }
        public virtual Modalidade Modalidade { get; set; }

        public int GravidadeId { get; set; }
        public virtual Gravidade Gravidade { get; set; }

        public int UrgenciaId { get; set; }
        public virtual Urgencia Urgencia { get; set; }

        public int TendenciaId { get; set; }
        public virtual Tendencia Tendencia { get; set; }


    }
}
