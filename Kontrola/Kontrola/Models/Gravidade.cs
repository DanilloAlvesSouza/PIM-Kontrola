using System.ComponentModel.DataAnnotations;

namespace Kontrola.Models
{
    public class Gravidade
    {
        public int GravidadeId { get; set; }
        public string Descricao { get; set; }

        public List<Chamado> Chamados { get; set; }
    }
}
