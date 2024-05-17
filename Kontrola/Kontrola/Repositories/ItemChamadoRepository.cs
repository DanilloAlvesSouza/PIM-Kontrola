using Kontrola.Context;
using Kontrola.Models;
using Kontrola.Repositories.Interfaces;

namespace Kontrola.Repositories
{
    public class ItemChamadoRepository : IItemChamadoRepository
    {
        private readonly AppDbContext _context;

        public ItemChamadoRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<ItemChamado> ItemChamados => _context.ItemChamados;

    }
}
