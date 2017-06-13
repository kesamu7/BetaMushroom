using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BetaMushroom.Models;
using BetaMushroom.Data;
using Microsoft.AspNetCore.Identity;


// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace BetaMushroom.Controllers
{
    public class ProfileController : Controller
    {

        private readonly ApplicationDbContext _context;

        private UserManager<ApplicationUser> _userManager;

        
        public ProfileController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }


        public async Task<IActionResult> Details(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var profile = await _context.Profiles
                .SingleOrDefaultAsync(m => m.ID == id);

            if(profile == null)
            {
                return NotFound();
            }

            return View(profile);
        }


        // GET: Profile/Edit/5
        public async Task<IActionResult> Edit()
        {

            ApplicationUser currentUser = await _userManager.GetUserAsync(User);

            var profile = await _context.Profiles.SingleOrDefaultAsync(m => m.ID == currentUser.ProfileId);


            return View(profile);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("Id,UserName,BirthDate,Description,ProfilePicture,User")] Profile profile)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(profile);
                    await _context.SaveChangesAsync();
                }

                catch (DbUpdateConcurrencyException)
                {
                    //if (!ProfileExists(profile.ID))
                    //{
                    //    return NotFound();
                    //}
                    //else
                    //{
                    //    throw;
                    //}
                }
                return RedirectToAction("Index");
            }
            return View(profile);
        }
        

    }
}
