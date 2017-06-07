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
        
        [Required]
        [Display(Name = "Mushroom Name")]
        public string Name { get; set; }

        public string Notes { get; set; }

        public int Quantity { get; set; }

        [Required]
        [Display(Name = "Type")]
        public int TypeID { get; set; }

        public List<SelectListItem> Types { get; set; }

        public AddMushroomViewModel() { }



        public AddMushroomViewModel(IEnumerable<MushroomType> types)
        {
            Types = new List<SelectListItem>();
            foreach(var type in types)
            {
                Types.Add(new SelectListItem
                {
                    Value = type.ID.ToString(),
                    Text = type.Name
                });
            }
        }


    }
}
