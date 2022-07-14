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
    public class FilmeModelsController : Controller
    {
        private readonly CatalogoContex _context;

        public FilmeModelsController(CatalogoContex context)
        {
            _context = context;
        }

        // GET: FilmeModels
        public async Task<IActionResult> Index()
        {
              return _context.Catalogo != null ? 
                          View(await _context.Catalogo.ToListAsync()) :
                          Problem("Entity set 'CatalogoContex.Catalogo'  is null.");
        }

        // GET: FilmeModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Catalogo == null)
            {
                return NotFound();
            }

            var filmeModel = await _context.Catalogo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (filmeModel == null)
            {
                return NotFound();
            }

            return View(filmeModel);
        }

        // GET: FilmeModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FilmeModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,DataDeLancamento,Duracao")] FilmeModel filmeModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(filmeModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(filmeModel);
        }

        // GET: FilmeModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Catalogo == null)
            {
                return NotFound();
            }

            var filmeModel = await _context.Catalogo.FindAsync(id);
            if (filmeModel == null)
            {
                return NotFound();
            }
            return View(filmeModel);
        }

        // POST: FilmeModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,DataDeLancamento,Duracao")] FilmeModel filmeModel)
        {
            if (id != filmeModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(filmeModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FilmeModelExists(filmeModel.Id))
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
            return View(filmeModel);
        }

        // GET: FilmeModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Catalogo == null)
            {
                return NotFound();
            }

            var filmeModel = await _context.Catalogo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (filmeModel == null)
            {
                return NotFound();
            }

            return View(filmeModel);
        }

        // POST: FilmeModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Catalogo == null)
            {
                return Problem("Entity set 'CatalogoContex.Catalogo'  is null.");
            }
            var filmeModel = await _context.Catalogo.FindAsync(id);
            if (filmeModel != null)
            {
                _context.Catalogo.Remove(filmeModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FilmeModelExists(int id)
        {
          return (_context.Catalogo?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
