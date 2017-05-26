using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BetaMushroom.Models
{
    public class MushroomActivity
    {
        public int ID { get; set; }
        //public string Name { get; set; }
        public string Notes { get; set; }
        public byte [] MushroomImage { get; set; }

        public int TypeID { get; set; }
        public MushroomType Type { get; set; }
    }
}
