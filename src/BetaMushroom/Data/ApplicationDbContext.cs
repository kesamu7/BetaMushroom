using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BetaMushroom.Models;

namespace BetaMushroom.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public DbSet<MushroomActivity> Mushrooms { get; set; }
        public DbSet<MushroomType> Types { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<ProfileShrooms> ProfileShrooms { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public ApplicationDbContext()
            : base()
        {
            
        }
    }

    
}
