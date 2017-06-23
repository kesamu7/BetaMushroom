using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BetaMushroom.Models
{
    public class ProfileShrooms
    {
        public int ID { get; set; }

        public int ProfileID { get; set; }
        public Profile Profile { get; set; }

        public int ShroomID { get; set; }
        public MushroomActivity Mushroom { get; set; }
    }
}
