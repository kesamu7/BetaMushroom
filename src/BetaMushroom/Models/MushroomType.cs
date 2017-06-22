using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BetaMushroom.Models
{
    public class MushroomType
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public ApplicationUser User { get; set; }

        public IList<MushroomActivity> Mushrooms { get; set; }

    }
}
