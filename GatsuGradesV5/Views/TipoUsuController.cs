using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GatsuGradesV5.Models;

namespace GatsuGradesV5.Views
{
    public class TipoUsuController : Controller
    {
        private readonly GatsuGradesv6Context _context;

        public TipoUsuController(GatsuGradesv6Context context)
        {
            _context = context;
        }

        // GET: TipoUsu
        public async Task<IActionResult> Index()
        {
              return View(await _context.TipoUsuarios.ToListAsync());
        }

        // GET: TipoUsu/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TipoUsuarios == null)
            {
                return NotFound();
            }

            var tipoUsuario = await _context.TipoUsuarios
                .FirstOrDefaultAsync(m => m.IdTipou == id);
            if (tipoUsuario == null)
            {
                return NotFound();
            }

            return View(tipoUsuario);
        }

        // GET: TipoUsu/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoUsu/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTipou,TuDescrip")] TipoUsuario tipoUsuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoUsuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoUsuario);
        }

        // GET: TipoUsu/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TipoUsuarios == null)
            {
                return NotFound();
            }

            var tipoUsuario = await _context.TipoUsuarios.FindAsync(id);
            if (tipoUsuario == null)
            {
                return NotFound();
            }
            return View(tipoUsuario);
        }

        // POST: TipoUsu/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTipou,TuDescrip")] TipoUsuario tipoUsuario)
        {
            if (id != tipoUsuario.IdTipou)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoUsuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoUsuarioExists(tipoUsuario.IdTipou))
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
            return View(tipoUsuario);
        }

        // GET: TipoUsu/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TipoUsuarios == null)
            {
                return NotFound();
            }

            var tipoUsuario = await _context.TipoUsuarios
                .FirstOrDefaultAsync(m => m.IdTipou == id);
            if (tipoUsuario == null)
            {
                return NotFound();
            }

            return View(tipoUsuario);
        }

        // POST: TipoUsu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TipoUsuarios == null)
            {
                return Problem("Entity set 'GatsuGradesv6Context.TipoUsuarios'  is null.");
            }
            var tipoUsuario = await _context.TipoUsuarios.FindAsync(id);
            if (tipoUsuario != null)
            {
                _context.TipoUsuarios.Remove(tipoUsuario);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoUsuarioExists(int id)
        {
          return _context.TipoUsuarios.Any(e => e.IdTipou == id);
        }
    }
}
