using Kontrola.Context;
using Kontrola.Models;
using Kontrola.Repositories.Interfaces;

namespace Kontrola.Repositories
{
    public class TendenciaRepository : ITendenciaRepository
    {
        private readonly AppDbContext _context;

        public TendenciaRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Tendencia> Tendencias => _context.Tendencias;
    }
}
