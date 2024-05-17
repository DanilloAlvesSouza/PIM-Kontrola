using Kontrola.Models;

namespace Kontrola.Repositories.Interfaces
{
    public interface IClienteRepository
    {
        IEnumerable<Cliente> Clientes { get; }
    }
}
