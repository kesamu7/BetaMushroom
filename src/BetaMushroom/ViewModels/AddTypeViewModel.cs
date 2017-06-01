using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using BetaMushroom.Models;
using BetaMushroom.Data;
using System.ComponentModel.DataAnnotations;

namespace BetaMushroom.ViewModels
{
    public class AddTypeViewModel
    {
        [Required]
        [Display(Name = "Type")]
        public string Name { get; set; }
    }
}
