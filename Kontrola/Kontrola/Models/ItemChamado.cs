namespace Kontrola.Models
{
    public class ItemChamado
    {
        public string ItemChamadoId { get; set; }
        public virtual Chamado Chamado { get; set; }
        public int EquipamentoId { get; set; }
        public virtual Equipamento Equipamento { get; set; }
    }
}
