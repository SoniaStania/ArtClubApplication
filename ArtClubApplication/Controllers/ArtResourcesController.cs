using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ArtClubApplication.Data;
using ArtClubApplication.Models;

namespace ArtClubApplication.Controllers
{
    public class ArtResourcesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ArtResourcesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ArtResources
        public async Task<IActionResult> Index()
        {
              return _context.ArtResource != null ? 
                          View(await _context.ArtResource.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.ArtResource'  is null.");
        }

        // GET: ArtResources/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ArtResource == null)
            {
                return NotFound();
            }

            var artResource = await _context.ArtResource
                .FirstOrDefaultAsync(m => m.ArtResourceId == id);
            if (artResource == null)
            {
                return NotFound();
            }

            return View(artResource);
        }

        // GET: ArtResources/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ArtResources/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ArtResourceId,Name,Status,Price")] ArtResource artResource)
        {
            if (ModelState.IsValid)
            {
                _context.Add(artResource);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(artResource);
        }

        // GET: ArtResources/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ArtResource == null)
            {
                return NotFound();
            }

            var artResource = await _context.ArtResource.FindAsync(id);
            if (artResource == null)
            {
                return NotFound();
            }
            return View(artResource);
        }

        // POST: ArtResources/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ArtResourceId,Name,Status,Price")] ArtResource artResource)
        {
            if (id != artResource.ArtResourceId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(artResource);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArtResourceExists(artResource.ArtResourceId))
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
            return View(artResource);
        }

        // GET: ArtResources/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ArtResource == null)
            {
                return NotFound();
            }

            var artResource = await _context.ArtResource
                .FirstOrDefaultAsync(m => m.ArtResourceId == id);
            if (artResource == null)
            {
                return NotFound();
            }

            return View(artResource);
        }

        // POST: ArtResources/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ArtResource == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ArtResource'  is null.");
            }
            var artResource = await _context.ArtResource.FindAsync(id);
            if (artResource != null)
            {
                _context.ArtResource.Remove(artResource);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArtResourceExists(int id)
        {
          return (_context.ArtResource?.Any(e => e.ArtResourceId == id)).GetValueOrDefault();
        }
    }
}
