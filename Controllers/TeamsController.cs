using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SportWebApplication;

namespace SportWebApplication.Controllers
{
    public class TeamsController : Controller
    {
        private readonly DBSportContext _context;

        public TeamsController(DBSportContext context)
        {
            _context = context;
        }

        // GET: Teams
        public async Task<IActionResult> Index(int? id,string? name)
        {
            if (id == null) return RedirectToAction("Sports", "Index");
            ViewBag.SportId = id;
            ViewBag.SportName = name;
            var teamsBySport=_context.Teams.Where(t=>t.SportId==id).Include(t=>t.Coach).Include(t => t.City).Include(t => t.Coach).Include(t => t.Sport);
            //var dBSportContext = _context.Teams.Include(t => t.City).Include(t => t.Coach).Include(t => t.Sport);
            return View(await teamsBySport.ToListAsync());
        }

        // GET: Teams/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var team = await _context.Teams
                .Include(t => t.City)
                .Include(t => t.Coach)
                .Include(t => t.Sport)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (team == null)
            {
                return NotFound();
            }

            //return View(team);
            return RedirectToAction("Index", "Players", new { id = team.Id, name = team.Name });
        }

        // GET: Teams/Create
        public IActionResult Create(int sportId)
        {
            ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Name");
            ViewData["CoachId"] = new SelectList(_context.Coaches, "Id", "Surname");
            //  ViewData["SportId"] = new SelectList(_context.Sports, "Id", "Name");
            ViewBag.SportId = sportId;
            ViewBag.SportName = _context.Sports.Where(s => s.Id == sportId).FirstOrDefault().Name;              
            return View();
        }

        // POST: Teams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int sportId, [Bind("Id,Name,DateOfCreation,SportId,CityId,CoachId")] Team team)
        {
            team.SportId = sportId;
            if (ModelState.IsValid)
            {
                _context.Add(team);
                await _context.SaveChangesAsync();
                // return RedirectToAction(nameof(Index));
                return RedirectToAction("Index", "Teams", new { id = sportId, name = _context.Sports.Where(s => s.Id == sportId).FirstOrDefault().Name });
            }
            ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Name", team.CityId);
            ViewData["CoachId"] = new SelectList(_context.Coaches, "Id", "Surname", team.CoachId);
            // ViewData["SportId"] = new SelectList(_context.Sports, "Id", "Name", team.SportId);
            //return View(team);
            return RedirectToAction("Index", "Teams", new { id = sportId, name = _context.Sports.Where(s => s.Id == sportId).FirstOrDefault().Name });
        }

        // GET: Teams/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var team = await _context.Teams.FindAsync(id);
            if (team == null)
            {
                return NotFound();
            }
            ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Name", team.CityId);
            ViewData["CoachId"] = new SelectList(_context.Coaches, "Id", "Surname", team.CoachId);
            ViewData["SportId"] = new SelectList(_context.Sports, "Id", "Name", team.SportId);
            return View(team);
        }

        // POST: Teams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,DateOfCreation,SportId,CityId,CoachId")] Team team)
        {
            if (id != team.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(team);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeamExists(team.Id))
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
            ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Name", team.CityId);
            ViewData["CoachId"] = new SelectList(_context.Coaches, "Id", "Surname", team.CoachId);
            ViewData["SportId"] = new SelectList(_context.Sports, "Id", "Name", team.SportId);
            return View(team);
        }

        // GET: Teams/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var team = await _context.Teams
                .Include(t => t.City)
                .Include(t => t.Coach)
                .Include(t => t.Sport)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (team == null)
            {
                return NotFound();
            }

            return View(team);
        }

        // POST: Teams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var team = await _context.Teams.FindAsync(id);
            _context.Teams.Remove(team);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeamExists(int id)
        {
            return _context.Teams.Any(e => e.Id == id);
        }
    }
}
