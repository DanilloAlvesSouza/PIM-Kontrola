using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Kontrola.Context;
using Kontrola.Models;
using Microsoft.AspNetCore.Authorization;

namespace Kontrola.Controllers
{

    public class ChamadosController : Controller
    {
        private readonly AppDbContext _context;

        public ChamadosController(AppDbContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "Admin,Membro")]
        public async Task<IActionResult> Index()
        {

            var appDbContext = _context.Chamados.Include(c => c.Gravidade).Include(c => c.Cliente).Include(c => c.Modalidade).Include(c => c.Status).Include(c => c.Tendencia).Include(c => c.Urgencia);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Chamados/Details/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Chamados == null)
            {
                return NotFound();
            }

            var chamado = await _context.Chamados
                .Include(c => c.Cliente)
                .Include(c => c.Gravidade)
                .Include(c => c.Modalidade)
                .Include(c => c.Status)
                .Include(c => c.Tendencia)
                .Include(c => c.Urgencia)
                .FirstOrDefaultAsync(m => m.ChamadoId == id);
            if (chamado == null)
            {
                return NotFound();
            }

            return View(chamado);
        }

        // GET: Chamados/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "Nome");
            ViewData["GravidadeId"] = new SelectList(_context.Gravidades, "GravidadeId", "Descricao");
            ViewData["ModalidadeId"] = new SelectList(_context.Modalidades, "ModalidadeId", "Descricao");
            ViewData["StatusId"] = new SelectList(_context.Status, "StatusId", "Descricao");
            ViewData["TendenciaId"] = new SelectList(_context.Tendencias, "TendenciaId", "Descricao");
            ViewData["UrgenciaId"] = new SelectList(_context.Urgencias, "UrgenciaId", "Descricao");
            return View();
        }

        // POST: Chamados/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([Bind("ChamadoId,DataInicio,DataFechamento,Descricao,Diagnostico,Pendencia,Conclusao,ClienteId,StatusId,ModalidadeId,GravidadeId,UrgenciaId,TendenciaId")] Chamado chamado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chamado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "ClienteId", chamado.ClienteId);
            ViewData["GravidadeId"] = new SelectList(_context.Gravidades, "GravidadeId", "GravidadeId", chamado.GravidadeId);
            ViewData["ModalidadeId"] = new SelectList(_context.Modalidades, "ModalidadeId", "ModalidadeId", chamado.ModalidadeId);
            ViewData["StatusId"] = new SelectList(_context.Status, "StatusId", "StatusId", chamado.StatusId);
            ViewData["TendenciaId"] = new SelectList(_context.Tendencias, "TendenciaId", "TendenciaId", chamado.TendenciaId);
            ViewData["UrgenciaId"] = new SelectList(_context.Urgencias, "UrgenciaId", "UrgenciaId", chamado.UrgenciaId);
            return View(chamado);
        }

        // GET: Chamados/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Chamados == null)
            {
                return NotFound();
            }

            var chamado = await _context.Chamados.FindAsync(id);
            if (chamado == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "Nome", chamado.ClienteId);
            ViewData["GravidadeId"] = new SelectList(_context.Gravidades, "GravidadeId", "Descricao", chamado.GravidadeId);
            ViewData["ModalidadeId"] = new SelectList(_context.Modalidades, "ModalidadeId", "Descricao", chamado.ModalidadeId);
            ViewData["StatusId"] = new SelectList(_context.Status, "StatusId", "Descricao", chamado.StatusId);
            ViewData["TendenciaId"] = new SelectList(_context.Tendencias, "TendenciaId", "Descricao", chamado.TendenciaId);
            ViewData["UrgenciaId"] = new SelectList(_context.Urgencias, "UrgenciaId", "Descricao", chamado.UrgenciaId);
            return View(chamado);
        }

        // POST: Chamados/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("ChamadoId,DataInicio,DataFechamento,Descricao,Diagnostico,Pendencia,Conclusao,StatusId,ModalidadeId,GravidadeId,UrgenciaId,TendenciaId,ClienteId")] Chamado chamado)
        {
            if (id != chamado.ChamadoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chamado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChamadoExists(chamado.ChamadoId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "ClienteId", chamado.GravidadeId);
            ViewData["GravidadeId"] = new SelectList(_context.Gravidades, "GravidadeId", "GravidadeId", chamado.GravidadeId);
            ViewData["ModalidadeId"] = new SelectList(_context.Modalidades, "ModalidadeId", "ModalidadeId", chamado.ModalidadeId);
            ViewData["StatusId"] = new SelectList(_context.Status, "StatusId", "StatusId", chamado.StatusId);
            ViewData["TendenciaId"] = new SelectList(_context.Tendencias, "TendenciaId", "TendenciaId", chamado.TendenciaId);
            ViewData["UrgenciaId"] = new SelectList(_context.Urgencias, "UrgenciaId", "UrgenciaId", chamado.UrgenciaId);
            return View(chamado);
        }

        // GET: Chamados/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Chamados == null)
            {
                return NotFound();
            }

            var chamado = await _context.Chamados
                .Include(c => c.Cliente)
                .Include(c => c.Gravidade)
                .Include(c => c.Modalidade)
                .Include(c => c.Status)
                .Include(c => c.Tendencia)
                .Include(c => c.Urgencia)
                .FirstOrDefaultAsync(m => m.ChamadoId == id);
            if (chamado == null)
            {
                return NotFound();
            }

            return View(chamado);
        }

        // POST: Chamados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Chamados == null)
            {
                return Problem("Entity set 'AppDbContext.Chamados'  is null.");
            }
            var chamado = await _context.Chamados.FindAsync(id);
            if (chamado != null)
            {
                _context.Chamados.Remove(chamado);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChamadoExists(int id)
        {
            return _context.Chamados.Any(e => e.ChamadoId == id);
        }
    }
}
