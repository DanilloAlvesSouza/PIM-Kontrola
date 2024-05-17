using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Kontrola.Context;
using Kontrola.Models;

namespace Kontrola.Controllers
{
    public class ChamadosController : Controller
    {
        private readonly AppDbContext _context;

        public ChamadosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Chamados
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Chamados.Include(c => c.Gravidade).Include(c => c.Modalidade).Include(c => c.Status).Include(c => c.Tendencia).Include(c => c.Urgencia);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Chamados/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Chamados == null)
            {
                return NotFound();
            }

            var chamado = await _context.Chamados
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
        public IActionResult Create()
        {
            ViewData["GravidadeId"] = new SelectList(_context.Gravidades, "GravidadeId", "GravidadeId");
            ViewData["ModalidadeId"] = new SelectList(_context.Modalidades, "ModalidadeId", "ModalidadeId");
            ViewData["StatusId"] = new SelectList(_context.Status, "StatusId", "StatusId");
            ViewData["TendenciaId"] = new SelectList(_context.Tendencias, "TendenciaId", "TendenciaId");
            ViewData["UrgenciaId"] = new SelectList(_context.Urgencias, "UrgenciaId", "UrgenciaId");
            return View();
        }

        // POST: Chamados/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ChamadoId,DataInicio,DataFechamento,Descricao,Diagnostico,Pendencia,Conclusao,StatusId,ModalidadeId,GravidadeId,UrgenciaId,TendenciaId")] Chamado chamado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chamado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GravidadeId"] = new SelectList(_context.Gravidades, "GravidadeId", "GravidadeId", chamado.GravidadeId);
            ViewData["ModalidadeId"] = new SelectList(_context.Modalidades, "ModalidadeId", "ModalidadeId", chamado.ModalidadeId);
            ViewData["StatusId"] = new SelectList(_context.Status, "StatusId", "StatusId", chamado.StatusId);
            ViewData["TendenciaId"] = new SelectList(_context.Tendencias, "TendenciaId", "TendenciaId", chamado.TendenciaId);
            ViewData["UrgenciaId"] = new SelectList(_context.Urgencias, "UrgenciaId", "UrgenciaId", chamado.UrgenciaId);
            return View(chamado);
        }

        // GET: Chamados/Edit/5
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
            ViewData["GravidadeId"] = new SelectList(_context.Gravidades, "GravidadeId", "GravidadeId", chamado.GravidadeId);
            ViewData["ModalidadeId"] = new SelectList(_context.Modalidades, "ModalidadeId", "ModalidadeId", chamado.ModalidadeId);
            ViewData["StatusId"] = new SelectList(_context.Status, "StatusId", "StatusId", chamado.StatusId);
            ViewData["TendenciaId"] = new SelectList(_context.Tendencias, "TendenciaId", "TendenciaId", chamado.TendenciaId);
            ViewData["UrgenciaId"] = new SelectList(_context.Urgencias, "UrgenciaId", "UrgenciaId", chamado.UrgenciaId);
            return View(chamado);
        }

        // POST: Chamados/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ChamadoId,DataInicio,DataFechamento,Descricao,Diagnostico,Pendencia,Conclusao,StatusId,ModalidadeId,GravidadeId,UrgenciaId,TendenciaId")] Chamado chamado)
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
            ViewData["GravidadeId"] = new SelectList(_context.Gravidades, "GravidadeId", "GravidadeId", chamado.GravidadeId);
            ViewData["ModalidadeId"] = new SelectList(_context.Modalidades, "ModalidadeId", "ModalidadeId", chamado.ModalidadeId);
            ViewData["StatusId"] = new SelectList(_context.Status, "StatusId", "StatusId", chamado.StatusId);
            ViewData["TendenciaId"] = new SelectList(_context.Tendencias, "TendenciaId", "TendenciaId", chamado.TendenciaId);
            ViewData["UrgenciaId"] = new SelectList(_context.Urgencias, "UrgenciaId", "UrgenciaId", chamado.UrgenciaId);
            return View(chamado);
        }

        // GET: Chamados/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Chamados == null)
            {
                return NotFound();
            }

            var chamado = await _context.Chamados
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
