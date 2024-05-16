using Kontrola.Models;

namespace Kontrola.Repositories.Interfaces
{
    public interface ITendenciaRepository
    {
        IEnumerable<Tendencia> Tendencias { get; }
    }
}
