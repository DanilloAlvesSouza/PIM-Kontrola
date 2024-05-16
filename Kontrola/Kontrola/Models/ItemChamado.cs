namespace KontrolaPoc.Models
{
    public class ItemChamado
    {
        public int ItemChamadoId { get; set; }
        public int ChamadoId { get; set; }
        public virtual Chamado Chamado { get; set; }
        public int EquipamentoId { get; set; }
        public virtual Equipamento Equipamento { get; set; }
    }
}
