using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Model29.Models;

namespace Model29.Controllers
{
    public class AtorModelsController : Controller
    {
        private readonly CatalogoContex _context;

        public AtorModelsController(CatalogoContex context)
        {
            _context = context;
        }

        // GET: AtorModels
        public async Task<IActionResult> Index()
        {
              return _context.Elenco != null ? 
                          View(await _context.Elenco.ToListAsync()) :
                          Problem("Entity set 'CatalogoContex.Elenco'  is null.");
        }

        // GET: AtorModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Elenco == null)
            {
                return NotFound();
            }

            var atorModel = await _context.Elenco
                .FirstOrDefaultAsync(m => m.Id == id);
            if (atorModel == null)
            {
                return NotFound();
            }

            return View(atorModel);
        }

        // GET: AtorModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AtorModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Sobrenome")] AtorModel atorModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(atorModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(atorModel);
        }

        // GET: AtorModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Elenco == null)
            {
                return NotFound();
            }

            var atorModel = await _context.Elenco.FindAsync(id);
            if (atorModel == null)
            {
                return NotFound();
            }
            return View(atorModel);
        }

        // POST: AtorModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Sobrenome")] AtorModel atorModel)
        {
            if (id != atorModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(atorModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AtorModelExists(atorModel.Id))
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
            return View(atorModel);
        }

        // GET: AtorModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Elenco == null)
            {
                return NotFound();
            }

            var atorModel = await _context.Elenco
                .FirstOrDefaultAsync(m => m.Id == id);
            if (atorModel == null)
            {
                return NotFound();
            }

            return View(atorModel);
        }

        // POST: AtorModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Elenco == null)
            {
                return Problem("Entity set 'CatalogoContex.Elenco'  is null.");
            }
            var atorModel = await _context.Elenco.FindAsync(id);
            if (atorModel != null)
            {
                _context.Elenco.Remove(atorModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AtorModelExists(int id)
        {
          return (_context.Elenco?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
