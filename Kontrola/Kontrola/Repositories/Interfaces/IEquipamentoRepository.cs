using Kontrola.Models;

namespace Kontrola.Repositories.Interfaces
{
    public interface IEquipamentoRepository
    {
        IEnumerable<Equipamento> Equipamentos { get; }
    }
}
