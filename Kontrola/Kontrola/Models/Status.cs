namespace Kontrola.Models
{
    public class Status
    {
        public int StatusId { get; set; }
        public  string Descricao { get; set; }

        public List<Chamado> Chamados { get; set; }
    }
}
