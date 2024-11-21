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
    public class UsuarioController : Controller
    {
        private readonly ApplicationContext _context;

        public UsuarioController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: Usuario
        public async Task<IActionResult> Index()
        {
            return View(await _context.Usuario.ToListAsync());
        }

        // GET: Usuario/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarioEntity = await _context.Usuario
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuarioEntity == null)
            {
                return NotFound();
            }

            return View(usuarioEntity);
        }

        // GET: Usuario/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Usuario/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Email,Senha")] UsuarioEntity usuarioEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usuarioEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(usuarioEntity);
        }

        // GET: Usuario/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarioEntity = await _context.Usuario.FindAsync(id);
            if (usuarioEntity == null)
            {
                return NotFound();
            }
            return View(usuarioEntity);
        }

        // POST: Usuario/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Nome,Email,Senha")] UsuarioEntity usuarioEntity)
        {
            if (id != usuarioEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuarioEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioEntityExists(usuarioEntity.Id))
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
            return View(usuarioEntity);
        }

        // GET: Usuario/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarioEntity = await _context.Usuario
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuarioEntity == null)
            {
                return NotFound();
            }

            return View(usuarioEntity);
        }

        // POST: Usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var usuarioEntity = await _context.Usuario.FindAsync(id);
            if (usuarioEntity != null)
            {
                _context.Usuario.Remove(usuarioEntity);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioEntityExists(string id)
        {
            return _context.Usuario.Any(e => e.Id == id);
        }
    }
}
