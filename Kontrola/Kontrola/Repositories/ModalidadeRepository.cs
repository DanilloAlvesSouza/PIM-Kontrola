using Kontrola.Context;
using Kontrola.Models;
using Kontrola.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Kontrola.Repositories
{
    public class ModalidadeRepository : IModalidadeRepository
    {
        private readonly AppDbContext _context;

        public ModalidadeRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Modalidade> Modalidades => _context.Modalidades;
    }
    
}
