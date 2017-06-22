using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using BetaMushroom.Models;
using System.Data;
using BetaMushroom.Data;

namespace BetaMushroom.Models
{
    public class ApplicationUser : IdentityUser
    {
        [ForeignKey("Profile")]
        public int ProfileId { get; set; }

        public Profile Profile { get; set; }

        public MushroomActivity mushActivity { get; set; }

        public MushroomType mushType { get; set; }

        public string FirstName { get; set; }

    }
}
