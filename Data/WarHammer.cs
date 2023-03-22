using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    internal class WarHammer : Weapon
    {
        public WarHammer(string name, float price, CountryOfOrigin origin, WarHammerType type) : base("WarHammer", price, origin)
        {
            Type = type;
        }

        public WarHammerType Type { get; }
    }
}
