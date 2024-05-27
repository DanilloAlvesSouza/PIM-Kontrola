using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace Kontrola.Models
{
    public class Equipamento
    {
        public int EquipamentoId { get; set; }

        [Required(ErrorMessage ="Campo obrigatório")]
        [StringLength(15)]
        public string Marca { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(30)]
        public string Modelo { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(30)]
        [Display(Name ="Numero de Serie")]
        public string NumeroSerie { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Potência")]
        public string Potencia { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Tipo de equipamento")]
        public string Tipo { get; set; }

        [Display(Name = "Tensão de entrada")]
        public string TensaoEntrada { get; set; }

        [Display(Name = "Tensão de saída")]
        public string TensaoSaida { get; set; }
        public List<ItemChamado> itemChamados { get; set; }

        [Required(ErrorMessage = "Selecione um cliente")]
        [Display(Name = "Cliente ?")]
        public int ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }

    }
}
