using Kontrola.Models;

namespace Kontrola.Repositories.Interfaces
{
    public interface IItemChamadoRepository
    {
        IEnumerable<ItemChamado> ItemChamados {  get; }
    }
}
