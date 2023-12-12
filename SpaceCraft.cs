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
        public string Type { get; set; }
        public int Capacity { get; set; } // maximum number of passengers
        public int Distance { get; set; } // maximum travel distance (million km)
        public bool GravityGenerator { get; set; }
        public bool AsteroDeflector { get; set; }

        public SpaceCraft(string name, string type, int capacity
            ,int distance, bool generator, bool deflector)
        {
            Name = name;
            Type = type;
            Capacity = capacity;
            Distance = distance;
            GravityGenerator = generator;
            AsteroDeflector = deflector;
        }
    }
}
