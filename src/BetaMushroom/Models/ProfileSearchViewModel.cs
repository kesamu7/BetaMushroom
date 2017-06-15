using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using BetaMushroom.Models;
using BetaMushroom.ViewModels;

namespace BetaMushroom.Models
{
    public class ProfileSearchViewModel
    {
        public Gender Gender { get; set; }

        [Display(Name = "Username")]
        public string UserName { get; set; }

        public int MinAge { get; set; }
        public int MaxAge { get; set; }

    }
}
