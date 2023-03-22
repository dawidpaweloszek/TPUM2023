using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    internal class BattleAxe : Weapon
    {
        public BattleAxe(string name, float price, CountryOfOrigin origin, BattleAxeType type) : base("BattleAxe", price, origin)
        {
            Type = type;
        }

        public BattleAxeType Type { get; }
    }
}
