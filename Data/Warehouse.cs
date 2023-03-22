using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Warehouse : IWarehouse
    {
        public List<Weapon> Stock { get; private set; }

        public Warehouse() 
        { 
            Stock = new List<Weapon>();
        }

        public void AddWeapons(List<Weapon> weapons)
        {
            Stock.AddRange(weapons);
        }
        
        public void RemoveWeapons(List<Weapon> weapons)
        {
            weapons.ForEach(weapon => Stock.Remove(weapon));
        }

        public List<Weapon> GetWeaponsOfType(string name)
        {
            return Stock.FindAll(weapon => weapon.Name == name);
        }

        public List<Weapon> GetWeaponsOfOrigin(CountryOfOrigin origin)
        {
            return Stock.FindAll(weapon => weapon.Origin == origin);
        }
    }
}
