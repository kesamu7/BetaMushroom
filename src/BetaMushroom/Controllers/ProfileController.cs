﻿using System;
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
using BetaMushroom.Data.Migrations;
using BetaMushroom.ViewModels;



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


        public async Task<IActionResult> Index()
        {
            List<Profile> profiles = _context.Profiles.ToList();
            return View(await _context.Mushrooms.ToListAsync());
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

        [HttpGet]
        public IActionResult Search()
        {
            ProfileSearchViewModel vm = new ProfileSearchViewModel();
            vm.MinAge = 18;
            vm.MaxAge = 100;
            
            
            
            return View(vm);

        }

        [HttpPost]
        public IActionResult Search(ProfileSearchViewModel vm)
        {
            List<ProfileSearchResultViewModel> result = new List<ProfileSearchResultViewModel>();
            if (ModelState.IsValid)
            {
                DateTime minDate = DateTime.Today.AddYears(-vm.MaxAge);
                DateTime maxDate = DateTime.Today.AddYears(-vm.MinAge);

                result = (from p in _context.Profiles
                          where p.Gender == vm.Gender
                          && p.Birthdate > minDate && p.Birthdate < maxDate

                          select new ProfileSearchResultViewModel
                          {
                              UserName = p.UserName,
                              ProfilePicture = $"{p.User.Id}/{p.ProfilePicture}",
                              Age = calculateAge(p.Birthdate),
                              Description = p.Description,                            
                              Gender = p.Gender,
                              ID = p.ID,


                          }
                          ).ToList();
            }
            return View("Result",result);
        }

        

        private int calculateAge(DateTime birthDate)
        {
            int age = DateTime.Today.Year - birthDate.Year;
            if(birthDate > DateTime.Today.AddYears(-age))
            {
                age--;
            }

            return age;
        }


        public IActionResult AddShroom(int id)
        {
            Profile profile = _context.Profiles.SingleOrDefault(p => p.ID == id);
            List<MushroomType> mushrooms = _context.Types.ToList();
            return View(new AddProfileShroomViewModel(profile, mushrooms));
        }

        [HttpPost]
        public IActionResult AddShroom(AddProfileShroomViewModel addProfileShroomViewModel)
        {
            if (ModelState.IsValid)
            {
                var mushroomID = addProfileShroomViewModel.MushroomID;
                var profileID = addProfileShroomViewModel.ProfileID;

                IList<ProfileShrooms> existingItems = _context.ProfileShrooms
                    .Where(pm => pm.ShroomID == mushroomID)
                    .Where(pm => pm.ProfileID == profileID).ToList();

                if(existingItems.Count == 0)
                {
                    ProfileShrooms profileShroom = new ProfileShrooms
                    {
                        ShroomID = mushroomID,
                        ProfileID = profileID
                    };

                    _context.ProfileShrooms.Add(profileShroom);
                    _context.SaveChanges();
                }
                return Redirect(string.Format("/Profile/ViewShrooms/{0}", addProfileShroomViewModel.ProfileID));
            }
            return View(addProfileShroomViewModel);
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
        public async Task<IActionResult> Edit([Bind("ID,UserName,Birthdate,Gender,Description,ProfilePicture,ProfilePictureFile,User")] Profile profile, IFormFile ProfilePictureFile)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser currentUser = await _userManager.GetUserAsync(User);

                if(ProfilePictureFile != null)
                {
                    string uploadPath = Path.Combine(_environment.WebRootPath, "uploads");
                    Directory.CreateDirectory(Path.Combine(uploadPath, currentUser.Id));

                    string filename = Path.GetFileName(ProfilePictureFile.FileName);
                    


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
