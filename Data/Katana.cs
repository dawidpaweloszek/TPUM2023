using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    internal class Katana : Weapon
    {
        public Katana(string name, float price, CountryOfOrigin origin, KatanaType type) : base("Katana", price, origin)
        {
            Type = type;
        }

        public KatanaType Type { get; }
    }
}
