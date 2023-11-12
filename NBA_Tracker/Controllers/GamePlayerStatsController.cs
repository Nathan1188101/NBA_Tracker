using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NBA_Tracker.Data;
using NBA_Tracker.Models;

namespace NBA_Tracker.Controllers
{
    [Authorize]
    public class GamePlayerStatsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GamePlayerStatsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GamePlayerStats
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.GamePlayerStats.Include(g => g.Game).Include(g => g.Player);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: GamePlayerStats/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.GamePlayerStats == null)
            {
                return NotFound();
            }

            var gamePlayerStats = await _context.GamePlayerStats
                .Include(g => g.Game)
                .Include(g => g.Player)
                .FirstOrDefaultAsync(m => m.StatId == id);
            if (gamePlayerStats == null)
            {
                return NotFound();
            }

            return View(gamePlayerStats);
        }

        // GET: GamePlayerStats/Create
        public IActionResult Create()
        {

            ViewData["GameId"] = new SelectList(_context.Games, "GameId", "Date");
            ViewData["PlayerId"] = new SelectList(_context.Players, "PlayerId", "LastName");
            return View();
        }

        // POST: GamePlayerStats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StatId,Points,Rebounds,Assists,Steals,Blocks,GameId,PlayerId")] GamePlayerStats gamePlayerStats)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gamePlayerStats);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GameId"] = new SelectList(_context.Games, "GameId", "Location", gamePlayerStats.GameId);
            ViewData["PlayerId"] = new SelectList(_context.Players, "PlayerId", "FirstName", gamePlayerStats.PlayerId);
            return View(gamePlayerStats);
        }

        // GET: GamePlayerStats/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.GamePlayerStats == null)
            {
                return NotFound();
            }

            var gamePlayerStats = await _context.GamePlayerStats.FindAsync(id);
            if (gamePlayerStats == null)
            {
                return NotFound();
            }
            ViewData["GameId"] = new SelectList(_context.Games, "GameId", "Date", gamePlayerStats.GameId);
            ViewData["PlayerId"] = new SelectList(_context.Players, "PlayerId", "LastName", gamePlayerStats.PlayerId);
            return View(gamePlayerStats);
        }

        // POST: GamePlayerStats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StatId,Points,Rebounds,Assists,Steals,Blocks,GameId,PlayerId")] GamePlayerStats gamePlayerStats)
        {
            if (id != gamePlayerStats.StatId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gamePlayerStats);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GamePlayerStatsExists(gamePlayerStats.StatId))
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
            ViewData["GameId"] = new SelectList(_context.Games, "GameId", "Location", gamePlayerStats.GameId);
            ViewData["PlayerId"] = new SelectList(_context.Players, "PlayerId", "FirstName", gamePlayerStats.PlayerId);
            return View(gamePlayerStats);
        }

        // GET: GamePlayerStats/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.GamePlayerStats == null)
            {
                return NotFound();
            }

            var gamePlayerStats = await _context.GamePlayerStats
                .Include(g => g.Game)
                .Include(g => g.Player)
                .FirstOrDefaultAsync(m => m.StatId == id);
            if (gamePlayerStats == null)
            {
                return NotFound();
            }

            return View(gamePlayerStats);
        }

        // POST: GamePlayerStats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.GamePlayerStats == null)
            {
                return Problem("Entity set 'ApplicationDbContext.GamePlayerStats'  is null.");
            }
            var gamePlayerStats = await _context.GamePlayerStats.FindAsync(id);
            if (gamePlayerStats != null)
            {
                _context.GamePlayerStats.Remove(gamePlayerStats);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GamePlayerStatsExists(int id)
        {
          return (_context.GamePlayerStats?.Any(e => e.StatId == id)).GetValueOrDefault();
        }
    }
}
