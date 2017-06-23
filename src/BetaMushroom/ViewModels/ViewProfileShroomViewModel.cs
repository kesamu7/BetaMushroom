using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using BetaMushroom.Models;

namespace BetaMushroom.ViewModels
{
    public class ViewProfileShroomViewModel
    {
        public IList<ProfileShrooms> Mushrooms { get; set; }
        public Profile Profile { get; set; }
    }
}
