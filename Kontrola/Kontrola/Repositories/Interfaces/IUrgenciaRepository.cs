using Kontrola.Models;

namespace Kontrola.Repositories.Interfaces
{
    public interface IUrgenciaRepository
    {
        IEnumerable<Urgencia> Urgencias { get; }
    }
}
