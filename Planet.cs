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
        public double Distance { get; set; } // distance from Earth (million km)
        public bool Habitable { get; set; }
        public int Diameter { get; set; }
        public int Temperature { get; set; }
        public bool Dwarf { get; set; }

        public Planet(string name, int position, double distance
            , bool habitable, int diameter, int temperature, bool dwarf)
        {
            Name = name;
            Position = position;
            Distance = distance;
            Habitable = habitable;
            Diameter = diameter;
            Temperature = temperature;
            Dwarf = dwarf;
        }
    }
}
