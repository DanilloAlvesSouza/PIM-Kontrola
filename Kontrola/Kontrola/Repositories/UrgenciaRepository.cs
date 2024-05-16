using Kontrola.Context;
using Kontrola.Models;
using Kontrola.Repositories.Interfaces;

namespace Kontrola.Repositories
{
    public class UrgenciaRepository : IUrgenciaRepository
    {
        private readonly AppDbContext _context;

        public UrgenciaRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Urgencia> Urgencias => _context.Urgencias;
    }

}
