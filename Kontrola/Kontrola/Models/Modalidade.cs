namespace KontrolaPoc.Models
{
    public class Modalidade
    {
        public int ModalidadeId { get; set; }
        public string Descricao { get; set; }

        public List<Chamado> Chamados { get; set; }
    }
}
