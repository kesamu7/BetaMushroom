using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BetaMushroom.Models
{
    public class Profile
    {
        public int ID { get; set; }

        [Display(Name ="Username")]
        public string UserName { get; set; }

        public DateTime Birthdate { get; set; }


        [Display(Name = "About me")]
        public string Description { get; set; }

        [Display(Name = "Profile Picture")]
        public string ProfilePicture { get; set; }


        public ApplicationUser User { get; set; }



    }
}
