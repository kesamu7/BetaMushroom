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
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;


// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace BetaMushroom.Controllers
{
    public class ProfileController : Controller
    {

        private readonly ApplicationDbContext _context;

        private UserManager<ApplicationUser> _userManager;
        private IHostingEnvironment _environment;

        
        public ProfileController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IHostingEnvironment environment)
        {
            _context = context;
            _userManager = userManager;
            _environment = environment;
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
        public async Task<IActionResult> Edit([Bind("Id,UserName,BirthDate,Description,ProfilePicture,ProfilePictureFile,User")] Profile profile, IFormFile ProfilePictureFile)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser currentUser = await _userManager.GetUserAsync(User);

                if(ProfilePictureFile != null)
                {
                    string uploadPath = Path.Combine(_environment.WebRootPath, "uploads");
                    Directory.CreateDirectory(Path.Combine(uploadPath, currentUser.Id));

                    string filename = ProfilePictureFile.FileName;
                    if (filename.Contains('\\'))
                    {
                        filename = filename.Split('\\').Last();
                    }

                    using (FileStream fs = new FileStream(Path.Combine(uploadPath, currentUser.Id, filename), FileMode.Create))
                    {
                        await ProfilePictureFile.CopyToAsync(fs);
                    }
                    profile.ProfilePicture = filename;


                }


                _context.Update(profile);
                await _context.SaveChangesAsync();
                
            }
            return View(profile);
        }
        

    }
}
