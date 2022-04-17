using COMP2084ProjectNinaLiu200479031.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using COMP2084ProjectNinaLiu200479031.Data;
using Microsoft.AspNetCore.Authorization;

namespace COMP2084ProjectNinaLiu200479031.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class RolesController : Controller
    {

        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly ApplicationDbContext _context;

        public RolesController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext context)
        {

            this.userManager = userManager;
            this.roleManager = roleManager;
            _context = context;
        }

        // GET: RolesController
        public IActionResult Index()
        {
            return View(roleManager.Roles);
        }

        // GET: RolesController/Details/5
        public async Task<IActionResult> DetailsAsync(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var role = await _context.Roles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (role == null)
            {
                return NotFound();
            }

            return View(role);
        }

        // GET: RolesController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RolesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RoleName")] Role role)
        {

            if (ModelState.IsValid)
            {


                IdentityResult result = await roleManager.CreateAsync(new IdentityRole(role.RoleName));

                if (result.Succeeded)
                {

                    return RedirectToAction("Index");
                }

                string errors = "";

                foreach (IdentityError error in result.Errors)
                {
                    errors += error.Description + "\n";
                }

                return Content("An error occurred. \n" + errors);


            }
            else
            {

                return View(role);
            }


        }

        // GET: RolesController/Edit/5
       
        public ActionResult Edit(string id)
        {
            return View();
        }  
        /* public async Task<IActionResult> Edit(string Id)
         {

            /*if (id == null)
             {
                 return NotFound();
             }

             var role = await _context.Roles.FindAsync(id);
             if (role == null)
             {
                 return NotFound();
             }

             return View(role);*/
          /* var role = await _context.Roles.FindAsync(Id);
            return View();


            //return RedirectToAction(nameof(Index));
        }  */

        // POST: RolesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string? id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RolesController/Delete/5
         public ActionResult Delete(string id)
         {
          return View();
         }

        // POST: RolesController/Delete/5
      //  [HttpPost]
       // [ValidateAntiForgeryToken]
        /*
        public async Task<IActionResult> Delete(string Id)
        {
            /*
            if (Id == null)
            {
                return NotFound();
            }

            var role = await _context.Roles
                .FirstOrDefaultAsync(m => m.Id == Id);
            if (role == null)
            {
                return NotFound();
            }

            return View(role);*/

           
            /*     IdentityRole role = await roleManager.FindByIdAsync(Id);
                 _ = roleManager.DeleteAsync(role);

                 return RedirectToAction(nameof(Index));
              
        }*/
       
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string Id)
        {
            /*
            var role = await _context.Roles.FindAsync(Id);
            _context.Roles.Remove(role);
             await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));*/
            IdentityRole role = await roleManager.FindByIdAsync(Id);
            _ = roleManager.DeleteAsync(role);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> ManageUsers(string id)
        {

            IdentityRole role = await roleManager.FindByIdAsync(id);

            if (role == null)
            {

                return RedirectToAction("Index");
            }

            List<IdentityUser> members = new List<IdentityUser>();
            List<IdentityUser> nonmembers = new List<IdentityUser>();

            foreach (IdentityUser currentUser in userManager.Users.ToList())
            {

                if (await userManager.IsInRoleAsync(currentUser, role.Name))
                {

                    members.Add(currentUser);
                }
                else
                {
                    nonmembers.Add(currentUser);
                }
            }

            RoleManagement model = new RoleManagement
            {
                Role = role,
                Members = members,
                NonMembers = nonmembers
            };
            return View(model);
        }

        [Route("RolesController/AddMemberToRole/{userId}/{roleId}")]

        public IActionResult AddMemberToRole(string userId, string roleId)
        {


            //userManager.AddToRoleAsync(userObjectAsWhole, RoleName)

            return Content("UserID = " + userId + " RoleID = " + roleId);
        }

    }
}
