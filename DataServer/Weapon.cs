using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("ShopServerDataTest")]
[assembly: InternalsVisibleTo("ShopServerLogicTest")]

namespace DataServer
{
    public class Weapon : IWeapon
    {
        public Weapon(string name, float price, CountryOfOrigin origin, WeaponType type)
        {
            Name = name;
            Price = price;
            Origin = origin;
            Id = Guid.NewGuid();
            Type = type;
        }

        public string Name { get; }
        public float Price
        {
            get => price;
            set
            {
                if (value == price)
                    return;
                price = value;
            }
        }
        public Guid Id { get; }
        public CountryOfOrigin Origin { get; }
        public WeaponType Type { get; }
        private float price;
    }
}
