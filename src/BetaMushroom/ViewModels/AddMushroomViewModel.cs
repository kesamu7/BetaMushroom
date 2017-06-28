using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BetaMushroom.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;


namespace BetaMushroom.ViewModels
{
    public class AddMushroomViewModel
    {
        private List<MushroomType> list;

        public Profile Profile { get; set; }
        public List<SelectListItem> Mushrooms { get; set; }

        public int ProfileID { get; set; }
        public int MushroomID { get; set; }

        public AddMushroomViewModel() { }

        public AddMushroomViewModel(Profile profile, IEnumerable<MushroomType> mushrooms)
        {
            Mushrooms = new List<SelectListItem>();

            foreach(var shroom in mushrooms)
            {
                Mushrooms.Add(new SelectListItem
                {
                    Value = shroom.ID.ToString(),
                    Text = shroom.Name
                });
            }
            Profile = profile;
        }

        public AddMushroomViewModel(List<MushroomType> list)
        {
            this.list = list;
        }

        [Display(Name = "Mushroom Name")]
        public string Name { get; set; }

        public string Notes { get; set; }

        public int Quantity { get; set; }

        public int Image { get; set; }

        [Required]
        [Display(Name = "Type")]
        public int TypeID { get; set; }

        public List<SelectListItem> Types { get; set; }

        


    }
}
