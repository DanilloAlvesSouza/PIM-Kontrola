using Kontrola.Models;

namespace Kontrola.ViewModels
{
    public class ChamadoListViewModel
    {
        public IEnumerable<Chamado> Chamados { get; set;}

        public string Cliente { get; set;}
    }
}
