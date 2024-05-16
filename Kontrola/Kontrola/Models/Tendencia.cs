namespace KontrolaPoc.Models
{
    public class Tendencia
    {
        public int TendenciaId { get; set; }
        public string Descricao { get; set; }

        public List<Chamado> Chamados { get; set; }
    }
}
