using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ArtClubApp.Models;
using ArtClubApplication.Data;

namespace ArtClubApplication.Controllers
{
    public class RezervationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RezervationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Rezervations
        public async Task<IActionResult> Index()
        {
              return _context.Rezervation != null ? 
                          View(await _context.Rezervation.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Rezervation'  is null.");
        }

        // GET: Rezervations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Rezervation == null)
            {
                return NotFound();
            }

            var rezervation = await _context.Rezervation
                .FirstOrDefaultAsync(m => m.RezervationId == id);
            if (rezervation == null)
            {
                return NotFound();
            }

            return View(rezervation);
        }

        // GET: Rezervations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rezervations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RezervationId")] Rezervation rezervation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rezervation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rezervation);
        }

        // GET: Rezervations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Rezervation == null)
            {
                return NotFound();
            }

            var rezervation = await _context.Rezervation.FindAsync(id);
            if (rezervation == null)
            {
                return NotFound();
            }
            return View(rezervation);
        }

        // POST: Rezervations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RezervationId")] Rezervation rezervation)
        {
            if (id != rezervation.RezervationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rezervation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RezervationExists(rezervation.RezervationId))
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
            return View(rezervation);
        }

        // GET: Rezervations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Rezervation == null)
            {
                return NotFound();
            }

            var rezervation = await _context.Rezervation
                .FirstOrDefaultAsync(m => m.RezervationId == id);
            if (rezervation == null)
            {
                return NotFound();
            }

            return View(rezervation);
        }

        // POST: Rezervations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Rezervation == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Rezervation'  is null.");
            }
            var rezervation = await _context.Rezervation.FindAsync(id);
            if (rezervation != null)
            {
                _context.Rezervation.Remove(rezervation);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RezervationExists(int id)
        {
          return (_context.Rezervation?.Any(e => e.RezervationId == id)).GetValueOrDefault();
        }
    }
}
