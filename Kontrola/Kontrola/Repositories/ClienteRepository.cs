using Kontrola.Models;
using Kontrola.Context;
using Kontrola.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Kontrola.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly AppDbContext _context;

        public ClienteRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Cliente> Clientes => _context.Clientes;
    }
}
