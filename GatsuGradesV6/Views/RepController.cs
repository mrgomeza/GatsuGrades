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
    public class RepController : Controller
    {
        private readonly GatsuGradesv6Context _context;

        public RepController(GatsuGradesv6Context context)
        {
            _context = context;
        }

        // GET: Rep
        public async Task<IActionResult> Index()
        {
            var gatsuGradesv6Context = _context.Representantes.Include(r => r.IdTipouNavigation);
            return View(await gatsuGradesv6Context.ToListAsync());
        }

        // GET: Rep/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Representantes == null)
            {
                return NotFound();
            }

            var representante = await _context.Representantes
                .Include(r => r.IdTipouNavigation)
                .FirstOrDefaultAsync(m => m.IdRep == id);
            if (representante == null)
            {
                return NotFound();
            }

            return View(representante);
        }

        // GET: Rep/Create
        public IActionResult Create()
        {
            ViewData["IdTipou"] = new SelectList(_context.TipoUsuarios, "IdTipou", "IdTipou");
            return View();
        }

        // POST: Rep/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdRep,RepUsu,IdTipou,RepNombre,RepApellido,RepCedula,RepDireccion,RepTelefono,RepPassword")] Representante representante, TipoUsuario idTipou)
        {
            representante.IdTipouNavigation = idTipou;
            if (ModelState.IsValid)
            {
                //_context.Add(representante);
                //await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
            }
            else
            {
#pragma warning disable CS8602 // Desreferencia de una referencia posiblemente NULL.
                var errors = ModelState.Select(selector: x => x.Value.Errors).Where(y => y.Count > 0).ToList();
#pragma warning restore CS8602 // Desreferencia de una referencia posiblemente NULL.
                
            }
            //ViewData["IdTipou"] = new SelectList(_context.TipoUsuarios, "IdTipou", "IdTipou", representante.IdTipou);
            return View(representante);
        }

        // GET: Rep/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Representantes == null)
            {
                return NotFound();
            }

            var representante = await _context.Representantes.FindAsync(id);
            if (representante == null)
            {
                return NotFound();
            }
            ViewData["IdTipou"] = new SelectList(_context.TipoUsuarios, "IdTipou", "IdTipou", representante.IdTipou);
            return View(representante);
        }

        // POST: Rep/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdRep,RepUsu,IdTipou,RepNombre,RepApellido,RepCedula,RepDireccion,RepTelefono,RepPassword")] Representante representante)
        {
            if (id != representante.IdRep)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(representante);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RepresentanteExists(representante.IdRep))
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
            ViewData["IdTipou"] = new SelectList(_context.TipoUsuarios, "IdTipou", "IdTipou", representante.IdTipou);
            return View(representante);
        }

        // GET: Rep/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Representantes == null)
            {
                return NotFound();
            }

            var representante = await _context.Representantes
                .Include(r => r.IdTipouNavigation)
                .FirstOrDefaultAsync(m => m.IdRep == id);
            if (representante == null)
            {
                return NotFound();
            }

            return View(representante);
        }

        // POST: Rep/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Representantes == null)
            {
                return Problem("Entity set 'GatsuGradesv6Context.Representantes'  is null.");
            }
            var representante = await _context.Representantes.FindAsync(id);
            if (representante != null)
            {
                _context.Representantes.Remove(representante);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RepresentanteExists(int id)
        {
          return _context.Representantes.Any(e => e.IdRep == id);
        }
    }
}
