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
    public class IndustriaController : Controller
    {
        private readonly ApplicationContext _context;

        public IndustriaController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: Industria
        public async Task<IActionResult> Index()
        {
            return View(await _context.Industria.ToListAsync());
        }

        // GET: Industria/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var industriaEntity = await _context.Industria
                .FirstOrDefaultAsync(m => m.Id == id);
            if (industriaEntity == null)
            {
                return NotFound();
            }

            return View(industriaEntity);
        }

        // GET: Industria/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Industria/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,CEP,Tipo")] IndustriaEntity industriaEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(industriaEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(industriaEntity);
        }

        // GET: Industria/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var industriaEntity = await _context.Industria.FindAsync(id);
            if (industriaEntity == null)
            {
                return NotFound();
            }
            return View(industriaEntity);
        }

        // POST: Industria/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Nome,CEP,Tipo")] IndustriaEntity industriaEntity)
        {
            if (id != industriaEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(industriaEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IndustriaEntityExists(industriaEntity.Id))
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
            return View(industriaEntity);
        }

        // GET: Industria/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var industriaEntity = await _context.Industria
                .FirstOrDefaultAsync(m => m.Id == id);
            if (industriaEntity == null)
            {
                return NotFound();
            }

            return View(industriaEntity);
        }

        // POST: Industria/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var industriaEntity = await _context.Industria.FindAsync(id);
            if (industriaEntity != null)
            {
                _context.Industria.Remove(industriaEntity);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IndustriaEntityExists(string id)
        {
            return _context.Industria.Any(e => e.Id == id);
        }
    }
}
