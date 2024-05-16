using Kontrola.Models;

namespace Kontrola.Repositories.Interfaces
{
    public interface IEnderecoRepository
    {
        IEnumerable<Endereco> Enderecos {  get; }
    }
}
