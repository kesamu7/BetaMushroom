using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using BetaMushroom.Models;

namespace BetaMushroom.ViewModels
{
    public class ProfileSearchViewModel
    {
        public Gender Gender { get; set; }

        [Display(Name = "I'm looking for ")]
        public string UserName { get; set; }

        public int MinAge { get; set; }
        public int MaxAge { get; set; }

    }
}
