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
    public class ArtPiecesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ArtPiecesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ArtPieces
        public async Task<IActionResult> Index()
        {
              return _context.ArtPiece != null ? 
                          View(await _context.ArtPiece.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.ArtPiece'  is null.");
        }

        // GET: ArtPieces/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ArtPiece == null)
            {
                return NotFound();
            }

            var artPiece = await _context.ArtPiece
                .FirstOrDefaultAsync(m => m.PieceId == id);
            if (artPiece == null)
            {
                return NotFound();
            }

            return View(artPiece);
        }

        // GET: ArtPieces/Create
       
        [Authorize(Roles = "Administrator")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: ArtPieces/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Create([Bind("PieceId,Name,Type,PhotoURL,Description,DateTime")] ArtPiece artPiece)
        {
            if (ModelState.IsValid)
            {
                _context.Add(artPiece);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(artPiece);
        }

        // GET: ArtPieces/Edit/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ArtPiece == null)
            {
                return NotFound();
            }

            var artPiece = await _context.ArtPiece.FindAsync(id);
            if (artPiece == null)
            {
                return NotFound();
            }
            return View(artPiece);
        }

        // POST: ArtPieces/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int id, [Bind("PieceId,Name,Type,PhotoURL,Description,DateTime")] ArtPiece artPiece)
        {
            if (id != artPiece.PieceId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(artPiece);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArtPieceExists(artPiece.PieceId))
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
            return View(artPiece);
        }

        // GET: ArtPieces/Delete/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ArtPiece == null)
            {
                return NotFound();
            }

            var artPiece = await _context.ArtPiece
                .FirstOrDefaultAsync(m => m.PieceId == id);
            if (artPiece == null)
            {
                return NotFound();
            }

            return View(artPiece);
        }

        // POST: ArtPieces/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ArtPiece == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ArtPiece'  is null.");
            }
            var artPiece = await _context.ArtPiece.FindAsync(id);
            if (artPiece != null)
            {
                _context.ArtPiece.Remove(artPiece);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArtPieceExists(int id)
        {
          return (_context.ArtPiece?.Any(e => e.PieceId == id)).GetValueOrDefault();
        }
    }
}
