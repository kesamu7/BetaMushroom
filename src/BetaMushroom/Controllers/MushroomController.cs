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

        


        
        

        

    }
}