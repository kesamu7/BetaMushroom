using BetaMushroom.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BetaMushroom.ViewModels
{
    public class ProfileSearchResultViewModel
    {
        
        public int ID { get; set; }

        public Gender Gender { get; set; }

        [Display(Name = "Username")]
        public string UserName { get; set; }

        public string Description { get; set; }

        [Display(Name = "Profile picture")]
        public string ProfilePicture { get; set; }

        public int Age { get; set; }
    }
}
