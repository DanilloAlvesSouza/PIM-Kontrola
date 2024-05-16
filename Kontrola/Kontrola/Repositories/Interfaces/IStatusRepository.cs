using Kontrola.Models;

namespace Kontrola.Repositories.Interfaces
{
    public interface IStatusRepository
    {
        IEnumerable<Status> Status { get; }
    }
}
