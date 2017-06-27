using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BetaMushroom.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace BetaMushroom.ViewModels
{
    public class AddProfileShroomViewModel
    {
        

        public Profile Profile { get; set; }

        public List<SelectListItem> Mushrooms { get; set; }
        
        public int ProfileID { get; set; }
        public int MushroomID { get; set; }

        public AddProfileShroomViewModel() { }

        public AddProfileShroomViewModel(Profile profile, IEnumerable<MushroomActivity> mushrooms)
        {
            Mushrooms = new List<SelectListItem>();

            foreach(var mushroom in mushrooms)
            {
                Mushrooms.Add(new SelectListItem
                {
                    Value = mushroom.ID.ToString(),
                    Text = mushroom.Name
                });
            }
            Profile = profile;
        }


        /*
        public AddProfileShroomViewModel(Profile profile, List<MushroomActivity> mushrooms)
        {
            Profile = profile;
            this.mushrooms = mushrooms;
        }*/
    }
}
