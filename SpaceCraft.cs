using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTest
{
    public class SpaceCraft
    {
        public string Name { get; set; }
        public int Capacity { get; set; } // maximum number of passengers
        public int Distance { get; set; } // availabe travel distance (million km)
        public int Tank { get; set; } // number of tank of spacecraft
        public SpaceCraft(string name, int capacity, int distance, int tank)
        {
            Name = name;
            Capacity = capacity;
            Distance = distance;
            Tank = tank;
        }
    }
}
