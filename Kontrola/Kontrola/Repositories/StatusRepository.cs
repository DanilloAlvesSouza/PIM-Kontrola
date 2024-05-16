using Kontrola.Context;
using Kontrola.Models;
using Kontrola.Repositories.Interfaces;

namespace Kontrola.Repositories
{
    public class StatusRepository : IStatusRepository
    {
        private readonly AppDbContext _context;

        public StatusRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Status> Status => _context.Status;
    }
}
