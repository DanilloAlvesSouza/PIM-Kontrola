namespace KontrolaPoc.Models
{
    public class Urgencia
    {
        public int UrgenciaId { get; set; }
        public string Descricao { get; set; }

        public List<Chamado> Chamados { get; set; }
    }
}
