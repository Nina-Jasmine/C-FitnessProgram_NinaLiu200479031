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
    public class FitnessCoachesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FitnessCoachesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FitnessCoaches
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            return View(await _context.FitnessCoach.ToListAsync());
        }

        // GET: FitnessCoaches/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fitnessCoach = await _context.FitnessCoach
                .FirstOrDefaultAsync(m => m.CoachID == id);
            if (fitnessCoach == null)
            {
                return NotFound();
            }

            return View(fitnessCoach);
        }

        // GET: FitnessCoaches/Create
       
        public IActionResult Create()
        {
            return View();
        }

        // POST: FitnessCoaches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CoachID,CoachName,Major,Introduction,PhotoLink")] FitnessCoach fitnessCoach)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fitnessCoach);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fitnessCoach);
        }

        // GET: FitnessCoaches/Edit/5
       
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fitnessCoach = await _context.FitnessCoach.FindAsync(id);
            if (fitnessCoach == null)
            {
                return NotFound();
            }
            return View(fitnessCoach);
        }

        // POST: FitnessCoaches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
         
        public async Task<IActionResult> Edit(int id, [Bind("CoachID,CoachName,Major,Introduction,PhotoLink")] FitnessCoach fitnessCoach)
        {
            if (id != fitnessCoach.CoachID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fitnessCoach);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FitnessCoachExists(fitnessCoach.CoachID))
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
            return View(fitnessCoach);
        }

        // GET: FitnessCoaches/Delete/5
       
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fitnessCoach = await _context.FitnessCoach
                .FirstOrDefaultAsync(m => m.CoachID == id);
            if (fitnessCoach == null)
            {
                return NotFound();
            }

            return View(fitnessCoach);
        }

        // POST: FitnessCoaches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
         
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fitnessCoach = await _context.FitnessCoach.FindAsync(id);
            _context.FitnessCoach.Remove(fitnessCoach);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FitnessCoachExists(int id)
        {
            return _context.FitnessCoach.Any(e => e.CoachID == id);
        }
    }
}
