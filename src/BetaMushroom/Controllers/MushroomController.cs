using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BetaMushroom.Models;
using BetaMushroom.ViewModels;
using BetaMushroom.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace BetaMushroom.Controllers
{
    public class MushroomController : Controller    
    {
        private ApplicationDbContext context;
        

        public MushroomController(ApplicationDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index()
        {
            IList<MushroomActivity> mushrooms = context.Mushrooms.Include(c => c.Type).ToList();
            return View(mushrooms);
        }

        public IActionResult Add()
        {
            AddMushroomViewModel addMushroomViewModel = new AddMushroomViewModel(context.Types.ToList());
            return View(addMushroomViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddMushroomViewModel addMushroomViewModel)
        {
            MushroomType mushroomType = context.Types.Single(m => m.ID == addMushroomViewModel.TypeID);

            if (ModelState.IsValid)
            {
                MushroomActivity newMushroom = new MushroomActivity
                {
                    
                    Type = mushroomType,
                    Notes = addMushroomViewModel.Notes,
                    Quantity = addMushroomViewModel.Quantity,
                    
                };

                context.Mushrooms.Add(newMushroom);
                context.SaveChanges();

                return Redirect("/Mushroom/Index");
            }

            addMushroomViewModel.Shrooms(context.Types.ToList());

            return View(addMushroomViewModel);
        }

        
        

        

    }
}