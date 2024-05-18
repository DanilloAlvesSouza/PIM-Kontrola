using Kontrola.Models;

namespace Kontrola.Repositories.Interfaces
{
    public interface IModalidadeRepository
    {
        IEnumerable<Modalidade> Modalidades { get; }
    }
}
