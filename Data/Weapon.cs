using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

[assembly: InternalsVisibleTo("DataTest")]
[assembly: InternalsVisibleTo("LogicTest")]


namespace Data
{
    internal class Weapon : IWeapon
    {
        [JsonConstructor]
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
