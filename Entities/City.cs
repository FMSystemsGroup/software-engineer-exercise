using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    /// <summary>
    /// This class represents a city with its name, state, and country
    /// </summary>
    public class City
    {
        public string Name { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        // This method returns a string representation of the city in the format "Name, State, Country"
        public override string ToString()
        {
            return Name + ", " + State + ", " + Country;
        }
    }
}
