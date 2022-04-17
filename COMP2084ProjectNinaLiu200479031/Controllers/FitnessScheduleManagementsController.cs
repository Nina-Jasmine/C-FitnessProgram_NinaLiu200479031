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
    
    public class FitnessScheduleManagementsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FitnessScheduleManagementsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FitnessScheduleManagements
        [Authorize(Roles = "Administrator, Client")]
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.FitnessScheduleManagement.Include(f => f.FitnessClientBooking);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: FitnessScheduleManagements/Details/5
        [Authorize(Roles = "Administrator, Client")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fitnessScheduleManagement = await _context.FitnessScheduleManagement
                .Include(f => f.FitnessClientBooking)
                .FirstOrDefaultAsync(m => m.ScheduleID == id);
            if (fitnessScheduleManagement == null)
            {
                return NotFound();
            }

            return View(fitnessScheduleManagement);
        }

        // GET: FitnessScheduleManagements/Create
        [Authorize(Roles = "Administrator, Client")]
        public IActionResult Create()
        {
            ViewData["BookingID"] = new SelectList(_context.FitnessClientBooking, "BookingID", "BookingID");
            return View();
        }

        // POST: FitnessScheduleManagements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ScheduleID,BookingID,ScheduledTime,Hours,IsAttend")] FitnessScheduleManagement fitnessScheduleManagement)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fitnessScheduleManagement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BookingID"] = new SelectList(_context.FitnessClientBooking, "BookingID", "BookingID", fitnessScheduleManagement.BookingID);
            return View(fitnessScheduleManagement);
        }

        // GET: FitnessScheduleManagements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fitnessScheduleManagement = await _context.FitnessScheduleManagement.FindAsync(id);
            if (fitnessScheduleManagement == null)
            {
                return NotFound();
            }
            ViewData["BookingID"] = new SelectList(_context.FitnessClientBooking, "BookingID", "BookingID", fitnessScheduleManagement.BookingID);
            return View(fitnessScheduleManagement);
        }

        // POST: FitnessScheduleManagements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ScheduleID,BookingID,ScheduledTime,Hours,IsAttend")] FitnessScheduleManagement fitnessScheduleManagement)
        {
            if (id != fitnessScheduleManagement.ScheduleID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fitnessScheduleManagement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FitnessScheduleManagementExists(fitnessScheduleManagement.ScheduleID))
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
            ViewData["BookingID"] = new SelectList(_context.FitnessClientBooking, "BookingID", "BookingID", fitnessScheduleManagement.BookingID);
            return View(fitnessScheduleManagement);
        }

        // GET: FitnessScheduleManagements/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fitnessScheduleManagement = await _context.FitnessScheduleManagement
                .Include(f => f.FitnessClientBooking)
                .FirstOrDefaultAsync(m => m.ScheduleID == id);
            if (fitnessScheduleManagement == null)
            {
                return NotFound();
            }

            return View(fitnessScheduleManagement);
        }

        // POST: FitnessScheduleManagements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fitnessScheduleManagement = await _context.FitnessScheduleManagement.FindAsync(id);
            _context.FitnessScheduleManagement.Remove(fitnessScheduleManagement);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FitnessScheduleManagementExists(int id)
        {
            return _context.FitnessScheduleManagement.Any(e => e.ScheduleID == id);
        }
    }
}
