using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BetaMushroom.Models;
using BetaMushroom.ViewModels;
using Microsoft.EntityFrameworkCore;
using BetaMushroom.Data;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace BetaMushroom.Controllers
{
    public class TypeController : Controller
    {
        private readonly ApplicationDbContext context;

        public TypeController(ApplicationDbContext dbContext)
        {
            context = dbContext;
        }
         

        // GET: /<controller>/
        public IActionResult Index()
        {
            List<MushroomType> types = context.Types.ToList();
            return View(types);
        }

        public IActionResult Add()
        {
            AddTypeViewModel addTypeViewModel = new AddTypeViewModel();
            return View(addTypeViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddTypeViewModel addTypeViewModel)
        {
            if (ModelState.IsValid)
            {
                var theType = addTypeViewModel.Name;
                MushroomType newType = new MushroomType
                {
                    Name = theType
                };

                context.Types.Add(newType);
                context.SaveChanges();
                return Redirect("/Types");
            }

            return View(addTypeViewModel);
        }
    }
}
