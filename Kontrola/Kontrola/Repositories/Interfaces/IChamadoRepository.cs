using Kontrola.Models;

namespace Kontrola.Repositories.Interfaces
{
    public interface IChamadoRepository
    {
        IEnumerable<Chamado> Chamados { get; }

        Chamado GetChamadoById(int chamadoId);

    }
}
