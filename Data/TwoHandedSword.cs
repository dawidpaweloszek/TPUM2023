using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    internal class TwoHandedSword : Weapon
    {
        public TwoHandedSword(string name, float price, CountryOfOrigin origin, TwoHandedSwordType type) : base("TwoHandedSword", price, origin)
        {
            Type = type;
        }

        public TwoHandedSwordType Type { get; }
    }
}
