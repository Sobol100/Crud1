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
    public class DrugaKlasaModelsController : Controller
    {
        private readonly MyDbcontext _context;

        public DrugaKlasaModelsController(MyDbcontext context)
        {
            _context = context;
        }

        // GET: DrugaKlasaModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.Model2.ToListAsync());
        }

        // GET: DrugaKlasaModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var drugaKlasaModel = await _context.Model2
                .FirstOrDefaultAsync(m => m.Id == id);
            if (drugaKlasaModel == null)
            {
                return NotFound();
            }

            return View(drugaKlasaModel);
        }

        // GET: DrugaKlasaModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DrugaKlasaModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Surname,Pesel,Age")] DrugaKlasaModel drugaKlasaModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(drugaKlasaModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(drugaKlasaModel);
        }

        // GET: DrugaKlasaModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var drugaKlasaModel = await _context.Model2.FindAsync(id);
            if (drugaKlasaModel == null)
            {
                return NotFound();
            }
            return View(drugaKlasaModel);
        }

        // POST: DrugaKlasaModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Surname,Pesel,Age")] DrugaKlasaModel drugaKlasaModel)
        {
            if (id != drugaKlasaModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(drugaKlasaModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DrugaKlasaModelExists(drugaKlasaModel.Id))
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
            return View(drugaKlasaModel);
        }

        // GET: DrugaKlasaModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var drugaKlasaModel = await _context.Model2
                .FirstOrDefaultAsync(m => m.Id == id);
            if (drugaKlasaModel == null)
            {
                return NotFound();
            }

            return View(drugaKlasaModel);
        }

        // POST: DrugaKlasaModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var drugaKlasaModel = await _context.Model2.FindAsync(id);
            _context.Model2.Remove(drugaKlasaModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DrugaKlasaModelExists(int id)
        {
            return _context.Model2.Any(e => e.Id == id);
        }
    }
}
