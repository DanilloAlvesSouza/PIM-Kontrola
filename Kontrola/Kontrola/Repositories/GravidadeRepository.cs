using Kontrola.Context;
using Kontrola.Models;
using Kontrola.Repositories.Interfaces;

namespace Kontrola.Repositories
{
    public class GravidadeRepository : IGravidadeRepository
    {
        private readonly AppDbContext _context;

        public GravidadeRepository(AppDbContext contexto)
        {
            _context = contexto;
        }

        public IEnumerable<Gravidade> Gravidades => _context.Gravidades;
    }
}
