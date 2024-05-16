using Kontrola.Context;
using Kontrola.Models;
using Kontrola.Repositories.Interfaces;

namespace Kontrola.Repositories
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly AppDbContext _context;

        public EnderecoRepository(AppDbContext context)
        {
            _context = context;        }

        public IEnumerable<Endereco> Enderecos => _context.Enderecos;
    }
}
