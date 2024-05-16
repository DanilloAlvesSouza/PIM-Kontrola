using Kontrola.Models;

namespace Kontrola.Repositories.Interfaces
{
    public interface IGravidadeRepository
    {
        IEnumerable<Gravidade> Gravidades { get; }
    }
}
