using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTest
{
    public class DataSource
    {
        public List<Planet> Planets { get; set; }
        public List<SpaceCraft> Crafts { get; set; }

        public DataSource() 
        {
            if (Planets == null) Planets = new List<Planet>();
            if (Crafts == null) Crafts = new List<SpaceCraft>();
        }
    }
}
