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
    
   
    public class FitnessClientBookingsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FitnessClientBookingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FitnessClientBookings
        [Authorize(Roles = "Administrator, Client")]
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.FitnessClientBooking.Include(f => f.Membership).Include(f => f.Program);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: FitnessClientBookings/Details/5
        [Authorize(Roles = "Administrator, Client")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fitnessClientBooking = await _context.FitnessClientBooking
                .Include(f => f.Membership)
                .Include(f => f.Program)
                .FirstOrDefaultAsync(m => m.BookingID == id);
            if (fitnessClientBooking == null)
            {
                return NotFound();
            }

            return View(fitnessClientBooking);
        }

        // GET: FitnessClientBookings/Create
        [Authorize(Roles = "Administrator, Client")]
        public IActionResult Create()
        {
            ViewData["MembershipID"] = new SelectList(_context.FitnessMembership, "MembershipID", "FullName");
            ViewData["ProgramID"] = new SelectList(_context.FitnessProgram, "ProgramID", "ProgramDescription");
            return View();
        }

        // POST: FitnessClientBookings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator, Client")]
        public async Task<IActionResult> Create([Bind("BookingID,ProgramID,MembershipID,Notes,StartDate")] FitnessClientBooking fitnessClientBooking)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fitnessClientBooking);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MembershipID"] = new SelectList(_context.FitnessMembership, "MembershipID", "FullName", fitnessClientBooking.MembershipID);
            ViewData["ProgramID"] = new SelectList(_context.FitnessProgram, "ProgramID", "ProgramDescription", fitnessClientBooking.ProgramID);
            return View(fitnessClientBooking);
        }

        // GET: FitnessClientBookings/Edit/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fitnessClientBooking = await _context.FitnessClientBooking.FindAsync(id);
            if (fitnessClientBooking == null)
            {
                return NotFound();
            }
            ViewData["MembershipID"] = new SelectList(_context.FitnessMembership, "MembershipID", "FullName", fitnessClientBooking.MembershipID);
            ViewData["ProgramID"] = new SelectList(_context.FitnessProgram, "ProgramID", "ProgramDescription", fitnessClientBooking.ProgramID);
            return View(fitnessClientBooking);
        }

        // POST: FitnessClientBookings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int id, [Bind("BookingID,ProgramID,MembershipID,Notes,StartDate")] FitnessClientBooking fitnessClientBooking)
        {
            if (id != fitnessClientBooking.BookingID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fitnessClientBooking);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FitnessClientBookingExists(fitnessClientBooking.BookingID))
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
            ViewData["MembershipID"] = new SelectList(_context.FitnessMembership, "MembershipID", "FullName", fitnessClientBooking.MembershipID);
            ViewData["ProgramID"] = new SelectList(_context.FitnessProgram, "ProgramID", "ProgramDescription", fitnessClientBooking.ProgramID);
            return View(fitnessClientBooking);
        }

        // GET: FitnessClientBookings/Delete/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fitnessClientBooking = await _context.FitnessClientBooking
                .Include(f => f.Membership)
                .Include(f => f.Program)
                .FirstOrDefaultAsync(m => m.BookingID == id);
            if (fitnessClientBooking == null)
            {
                return NotFound();
            }

            return View(fitnessClientBooking);
        }

        // POST: FitnessClientBookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fitnessClientBooking = await _context.FitnessClientBooking.FindAsync(id);
            _context.FitnessClientBooking.Remove(fitnessClientBooking);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FitnessClientBookingExists(int id)
        {
            return _context.FitnessClientBooking.Any(e => e.BookingID == id);
        }
    }
}
