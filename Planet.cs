using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTest
{
    public class Planet
    {
        public string Name { get; set; }
        public int Position { get; set; } // relative position from the Sun
        public int Distance { get; set; } // distance from Earth (million km)
        public Planet(string name, int position, int distance)
        {
            Name = name;
            Position = position;
            Distance = distance;
        }
    }
}
