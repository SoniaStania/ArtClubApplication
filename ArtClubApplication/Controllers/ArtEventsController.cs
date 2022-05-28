using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ArtClubApp.Models;
using ArtClubApplication.Data;
using Microsoft.AspNetCore.Authorization;

namespace ArtClubApplication.Controllers
{
    public class ArtEventsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ArtEventsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ArtEvents
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ArtEvent.Include(a => a.Category);
            return View(await applicationDbContext.ToListAsync());
        }
        //Get: ArtEvents/ShowSearchForm
        public async Task<IActionResult> ShowSearchForm()
        {
          
            return View();
        }

        //POST: ARTEVENTS/ShowSearchResults

        public async Task<IActionResult> ShowSearchResults(String SearchPhrase)
        {
            var artEvent = await _context.ArtEvent.ToListAsync();
            return View("Index", artEvent.Where(j => j.Name.Contains(SearchPhrase)));
        }





        // GET: ArtEvents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ArtEvent == null)
            {
                return NotFound();
            }

            var artEvent = await _context.ArtEvent
                .Include(a => a.Category)
                .FirstOrDefaultAsync(m => m.EventId == id);
            if (artEvent == null)
            {
                return NotFound();
            }

            return View(artEvent);
        }

        // GET: ArtEvents/Reservation
        public async Task<IActionResult> Reserve(int? id)
        {
            if (id == null || _context.ArtEvent == null)
            {
                return NotFound();
            }

            var artEvent = await _context.ArtEvent
                .Include(a => a.Category)
                .FirstOrDefaultAsync(m => m.EventId == id);
            if (artEvent == null)
            {
                return NotFound();
            }

            return View(artEvent);
        }
        [HttpPost, ActionName("Reserve")]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> ReserveConfirmed(int id)
        {
            if (_context.ArtEvent == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ArtEvent'  is null.");
            }
            var artEvent = await _context.ArtEvent.FindAsync(id);
            if (artEvent != null)
            {
                //_context.ArtEvent.Add(artEvent);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: ArtEvents/Create
        [Authorize]
       
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Set<Category>(), "CategoryId", "CategoryId");
            return View();
        }

        // POST: ArtEvents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        
        public async Task<IActionResult> Create([Bind("EventId,Name,ShortDescription,LongDescription,IsPreferedEvent,Price,PhotoURL,CategoryId,Status,CreatedDate")] ArtEvent artEvent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(artEvent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Set<Category>(), "CategoryId", "CategoryId", artEvent.CategoryId);
            return View(artEvent);
        }

        // GET: ArtEvents/Edit/5
        [Authorize]
    

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ArtEvent == null)
            {
                return NotFound();
            }

            var artEvent = await _context.ArtEvent.FindAsync(id);
            if (artEvent == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Set<Category>(), "CategoryId", "CategoryId", artEvent.CategoryId);
            return View(artEvent);
        }

        // POST: ArtEvents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
       
        public async Task<IActionResult> Edit(int id, [Bind("EventId,Name,ShortDescription,LongDescription,IsPreferedEvent,Price,PhotoURL,CategoryId,Status,CreatedDate")] ArtEvent artEvent)
        {
            if (id != artEvent.EventId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(artEvent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArtEventExists(artEvent.EventId))
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
            ViewData["CategoryId"] = new SelectList(_context.Set<Category>(), "CategoryId", "CategoryId", artEvent.CategoryId);
            return View(artEvent);
        }

        // GET: ArtEvents/Delete/5
        [Authorize]
      
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ArtEvent == null)
            {
                return NotFound();
            }

            var artEvent = await _context.ArtEvent
                .Include(a => a.Category)
                .FirstOrDefaultAsync(m => m.EventId == id);
            if (artEvent == null)
            {
                return NotFound();
            }

            return View(artEvent);
        }



        // POST: ArtEvents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
   
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ArtEvent == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ArtEvent'  is null.");
            }
            var artEvent = await _context.ArtEvent.FindAsync(id);
            if (artEvent != null)
            {
                _context.ArtEvent.Remove(artEvent);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArtEventExists(int id)
        {
          return (_context.ArtEvent?.Any(e => e.EventId == id)).GetValueOrDefault();
        }
    }
}
