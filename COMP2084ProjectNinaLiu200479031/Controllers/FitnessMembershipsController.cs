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
    [Authorize]
    public class FitnessMembershipsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FitnessMembershipsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FitnessMemberships
        
        public async Task<IActionResult> Index()
        {
            //Check the user role 
       
                return View(await _context.FitnessMembership.ToListAsync());
            }
             
         
        

        // GET: FitnessMemberships/Details/5
       
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fitnessMembership = await _context.FitnessMembership
                .FirstOrDefaultAsync(m => m.MembershipID == id);
            if (fitnessMembership == null)
            {
                return NotFound();
            }

            return View(fitnessMembership);
        }

        // GET: FitnessMemberships/Create

        
        public IActionResult Create()
        {
            return View();
        }

        // POST: FitnessMemberships/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
           
        public async Task<IActionResult> Create([Bind("MembershipID,FullName,Phone,Email,IsVIP,StartDate,LastFollowUp")] FitnessMembership fitnessMembership)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fitnessMembership);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fitnessMembership);
        }

        // GET: FitnessMemberships/Edit/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fitnessMembership = await _context.FitnessMembership.FindAsync(id);
            if (fitnessMembership == null)
            {
                return NotFound();
            }
            return View(fitnessMembership);
        }

        // POST: FitnessMemberships/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int id, [Bind("MembershipID,FullName,Phone,Email,IsVIP,StartDate,LastFollowUp")] FitnessMembership fitnessMembership)
        {
            if (id != fitnessMembership.MembershipID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fitnessMembership);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FitnessMembershipExists(fitnessMembership.MembershipID))
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
            return View(fitnessMembership);
        }

        // GET: FitnessMemberships/Delete/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fitnessMembership = await _context.FitnessMembership
                .FirstOrDefaultAsync(m => m.MembershipID == id);
            if (fitnessMembership == null)
            {
                return NotFound();
            }

            return View(fitnessMembership);
        }

        // POST: FitnessMemberships/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fitnessMembership = await _context.FitnessMembership.FindAsync(id);
            _context.FitnessMembership.Remove(fitnessMembership);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FitnessMembershipExists(int id)
        {
            return _context.FitnessMembership.Any(e => e.MembershipID == id);
        }
    }
}
