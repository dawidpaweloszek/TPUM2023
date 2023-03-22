using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public abstract class Weapon
    {
        public string Name { get; }
        public float Price { get; set; }
        public Guid Id { get; }
        public CountryOfOrigin Origin { get; }


        public Weapon(string name, float price, CountryOfOrigin origin) 
        { 
            Name = name;
            Price = price;
            Origin = origin;
            Id = Guid.NewGuid();
        }
    }
}
