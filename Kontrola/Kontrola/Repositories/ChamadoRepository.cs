using Kontrola.Context;
using Kontrola.Models;
using Kontrola.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Kontrola.Repositories
{
    public class ChamadoRepository : IChamadoRepository
    {
        private readonly AppDbContext _context;

        public ChamadoRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Chamado> Chamados => _context.Chamados;

        //public IEnumerable<Chamado> Chamados => _context.Chamados.Include(c =>c.Status)
        //.Include(c => c.DataInicio.ToString()).Include(c => c.DataFechamento.ToString());
        public Chamado GetChamadoById(int chamadoId)
        {
            return _context.Chamados.FirstOrDefault(I => I.ChamadoId == chamadoId);
        }
        
    }
}
