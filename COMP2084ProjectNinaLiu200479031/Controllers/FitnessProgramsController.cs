using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using COMP2084ProjectNinaLiu200479031.Data;
using COMP2084ProjectNinaLiu200479031.Models;
using Microsoft.AspNetCore.Authorization;

namespace COMP2084ProjectNinaLiu200479031.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class FitnessProgramsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FitnessProgramsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FitnessPrograms
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.FitnessProgram.Include(f => f.Coach);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: FitnessPrograms/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fitnessProgram = await _context.FitnessProgram
                .Include(f => f.Coach)
                .FirstOrDefaultAsync(m => m.ProgramID == id);
            if (fitnessProgram == null)
            {
                return NotFound();
            }

            return View(fitnessProgram);
        }

        // GET: FitnessPrograms/Create

        public IActionResult Create()
        {
            ViewData["CoachID"] = new SelectList(_context.FitnessCoach, "CoachID", "CoachName");
            return View();
        }

        // POST: FitnessPrograms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProgramID,ProgramName,ProgramDescription,CoachID,Pricing,ApplyVouchers,Period")] FitnessProgram fitnessProgram)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fitnessProgram);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CoachID"] = new SelectList(_context.FitnessCoach, "CoachID", "CoachName", fitnessProgram.CoachID);
            return View(fitnessProgram);
        }

        // GET: FitnessPrograms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fitnessProgram = await _context.FitnessProgram.FindAsync(id);
            if (fitnessProgram == null)
            {
                return NotFound();
            }
            ViewData["CoachID"] = new SelectList(_context.FitnessCoach, "CoachID", "CoachName", fitnessProgram.CoachID);
            return View(fitnessProgram);
        }

        // POST: FitnessPrograms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProgramID,ProgramName,ProgramDescription,CoachID,Pricing,ApplyVouchers,Period")] FitnessProgram fitnessProgram)
        {
            if (id != fitnessProgram.ProgramID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fitnessProgram);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FitnessProgramExists(fitnessProgram.ProgramID))
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
            ViewData["CoachID"] = new SelectList(_context.FitnessCoach, "CoachID", "CoachName", fitnessProgram.CoachID);
            return View(fitnessProgram);
        }

        // GET: FitnessPrograms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fitnessProgram = await _context.FitnessProgram
                .Include(f => f.Coach)
                .FirstOrDefaultAsync(m => m.ProgramID == id);
            if (fitnessProgram == null)
            {
                return NotFound();
            }

            return View(fitnessProgram);
        }

        // POST: FitnessPrograms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fitnessProgram = await _context.FitnessProgram.FindAsync(id);
            _context.FitnessProgram.Remove(fitnessProgram);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FitnessProgramExists(int id)
        {
            return _context.FitnessProgram.Any(e => e.ProgramID == id);
        }
    }
}
