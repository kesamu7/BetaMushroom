using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using BetaMushroom.Models;


namespace BetaMushroom.Models
{

    public enum Gender
    {
        Male,
        Female
    }


    public class Profile
    {
        public int ID { get; set; }

        public Gender Gender { get; set; }

        [Display(Name ="Username")]
        public string UserName { get; set; }

        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }


        [Display(Name = "About me")]
        public string Description { get; set; }

        [Display(Name = "Profile Picture")]
        public string ProfilePicture { get; set; }


        public ApplicationUser User { get; set; }

        public IList<MushroomActivity> Mushrooms { get; set; }





    }
}
