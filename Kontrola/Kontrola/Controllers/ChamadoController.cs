using Kontrola.Repositories.Interfaces;
using Kontrola.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Kontrola.Controllers
{
    public class ChamadoController : Controller
    {
        private readonly IChamadoRepository _chamadoRepository;

        public ChamadoController(IChamadoRepository chamadoRepository)
        {
            _chamadoRepository = chamadoRepository;
        }

        public IActionResult List()
        {
            //var chamados = _chamadoRepository.Chamados;
            //return View(chamados);

            var chamadosListViewModel = new ChamadoListViewModel();
            chamadosListViewModel.Chamados = _chamadoRepository.Chamados;
            chamadosListViewModel.Cliente = "Cliente";
            return View(chamadosListViewModel);
        }
    }
}
