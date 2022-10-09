using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GatsuGradesV6.Models;

namespace GatsuGradesV6.Views
{
    public class ProfesorController : Controller
    {
        private readonly GatsuGradesv6Context _context;

        public ProfesorController(GatsuGradesv6Context context)
        {
            _context = context;
        }

        // GET: Profesor
        public async Task<IActionResult> Index()
        {
            var gatsuGradesv6Context = _context.Profesors.Include(p => p.IdTipouNavigation);
            return View(await gatsuGradesv6Context.ToListAsync());
        }

        // GET: Profesor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Profesors == null)
            {
                return NotFound();
            }

            var profesor = await _context.Profesors
                .Include(p => p.IdTipouNavigation)
                .FirstOrDefaultAsync(m => m.IdProfesor == id);
            if (profesor == null)
            {
                return NotFound();
            }

            return View(profesor);
        }

        // GET: Profesor/Create
        public IActionResult Create()
        {
            ViewData["IdTipou"] = new SelectList(_context.TipoUsuarios, "IdTipou", "IdTipou");
            return View();
        }

        // POST: Profesor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdProfesor,ProfUsu,IdTipou,ProfNombre,ProfApellido,ProfCedula,ProfDireccion,ProfTelf,ProfPassword")] Profesor profesor)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(profesor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdTipou"] = new SelectList(_context.TipoUsuarios, "IdTipou", "IdTipou", profesor.IdTipou);
            return View(profesor);
        }

        // GET: Profesor/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Profesors == null)
            {
                return NotFound();
            }

            var profesor = await _context.Profesors.FindAsync(id);
            if (profesor == null)
            {
                return NotFound();
            }
            ViewData["IdTipou"] = new SelectList(_context.TipoUsuarios, "IdTipou", "IdTipou", profesor.IdTipou);
            return View(profesor);
        }

        // POST: Profesor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdProfesor,ProfUsu,IdTipou,ProfNombre,ProfApellido,ProfCedula,ProfDireccion,ProfTelf,ProfPassword")] Profesor profesor)
        {
            if (id != profesor.IdProfesor)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(profesor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfesorExists(profesor.IdProfesor))
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
            ViewData["IdTipou"] = new SelectList(_context.TipoUsuarios, "IdTipou", "IdTipou", profesor.IdTipou);
            return View(profesor);
        }

        // GET: Profesor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Profesors == null)
            {
                return NotFound();
            }

            var profesor = await _context.Profesors
                .Include(p => p.IdTipouNavigation)
                .FirstOrDefaultAsync(m => m.IdProfesor == id);
            if (profesor == null)
            {
                return NotFound();
            }

            return View(profesor);
        }

        // POST: Profesor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Profesors == null)
            {
                return Problem("Entity set 'GatsuGradesv6Context.Profesors'  is null.");
            }
            var profesor = await _context.Profesors.FindAsync(id);
            if (profesor != null)
            {
                _context.Profesors.Remove(profesor);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfesorExists(int id)
        {
          return _context.Profesors.Any(e => e.IdProfesor == id);
        }
    }
}
