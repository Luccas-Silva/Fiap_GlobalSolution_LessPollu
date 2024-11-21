using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LessPollu.MVC.AppData;
using LessPollu.MVC.Models;

namespace LessPollu.MVC.Controllers
{
    public class RelatorioController : Controller
    {
        private readonly ApplicationContext _context;

        public RelatorioController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: Relatorio
        public async Task<IActionResult> Index()
        {
            return View(await _context.Relatorio.ToListAsync());
        }

        // GET: Relatorio/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var relatorioEntity = await _context.Relatorio
                .FirstOrDefaultAsync(m => m.Id == id);
            if (relatorioEntity == null)
            {
                return NotFound();
            }

            return View(relatorioEntity);
        }

        // GET: Relatorio/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Relatorio/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,dataGeracao,periodoCobertura,Metricas,Observacoes")] RelatorioEntity relatorioEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(relatorioEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(relatorioEntity);
        }

        // GET: Relatorio/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var relatorioEntity = await _context.Relatorio.FindAsync(id);
            if (relatorioEntity == null)
            {
                return NotFound();
            }
            return View(relatorioEntity);
        }

        // POST: Relatorio/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,dataGeracao,periodoCobertura,Metricas,Observacoes")] RelatorioEntity relatorioEntity)
        {
            if (id != relatorioEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(relatorioEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RelatorioEntityExists(relatorioEntity.Id))
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
            return View(relatorioEntity);
        }

        // GET: Relatorio/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var relatorioEntity = await _context.Relatorio
                .FirstOrDefaultAsync(m => m.Id == id);
            if (relatorioEntity == null)
            {
                return NotFound();
            }

            return View(relatorioEntity);
        }

        // POST: Relatorio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var relatorioEntity = await _context.Relatorio.FindAsync(id);
            if (relatorioEntity != null)
            {
                _context.Relatorio.Remove(relatorioEntity);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RelatorioEntityExists(string id)
        {
            return _context.Relatorio.Any(e => e.Id == id);
        }
    }
}
