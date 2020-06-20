using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Crud1.Data;
using Crud1.Models;

namespace Crud1.Controllers
{
    public class DowolnaKlasaModelsController : Controller
    {
        private readonly MyDbcontext _context;

        public DowolnaKlasaModelsController(MyDbcontext context)
        {
            _context = context;
        }

        // GET: DowolnaKlasaModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.Model.ToListAsync());
        }

        // GET: DowolnaKlasaModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dowolnaKlasaModel = await _context.Model
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dowolnaKlasaModel == null)
            {
                return NotFound();
            }

            return View(dowolnaKlasaModel);
        }

        // GET: DowolnaKlasaModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DowolnaKlasaModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PhoneNumber,Nickname,Description,Address")] DowolnaKlasaModel dowolnaKlasaModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dowolnaKlasaModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dowolnaKlasaModel);
        }

        // GET: DowolnaKlasaModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dowolnaKlasaModel = await _context.Model.FindAsync(id);
            if (dowolnaKlasaModel == null)
            {
                return NotFound();
            }
            return View(dowolnaKlasaModel);
        }

        // POST: DowolnaKlasaModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PhoneNumber,Nickname,Description,Address")] DowolnaKlasaModel dowolnaKlasaModel)
        {
            if (id != dowolnaKlasaModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dowolnaKlasaModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DowolnaKlasaModelExists(dowolnaKlasaModel.Id))
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
            return View(dowolnaKlasaModel);
        }

        // GET: DowolnaKlasaModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dowolnaKlasaModel = await _context.Model
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dowolnaKlasaModel == null)
            {
                return NotFound();
            }

            return View(dowolnaKlasaModel);
        }

        // POST: DowolnaKlasaModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dowolnaKlasaModel = await _context.Model.FindAsync(id);
            _context.Model.Remove(dowolnaKlasaModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DowolnaKlasaModelExists(int id)
        {
            return _context.Model.Any(e => e.Id == id);
        }
    }
}
