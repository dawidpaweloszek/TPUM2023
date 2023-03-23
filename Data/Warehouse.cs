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
        public List<IWeapon> Stock { get; }

        public Warehouse() 
        { 
            Stock = new List<IWeapon>();

            // TODO: @Ignacy - temporary we can add weapons here
            Stock.Add(new Weapon("Toporek fantastyczny", 200f, CountryOfOrigin.China, WeaponType.BattleAxe));
            Stock.Add(new Weapon("Młotek fantastyczny", 300.5f, CountryOfOrigin.Germany, WeaponType.WarHammer));
            Stock.Add(new Weapon("Katana fajowska", 1000f, CountryOfOrigin.Japan, WeaponType.Katana));
            Stock.Add(new Weapon("Miecz taki polski", 250f, CountryOfOrigin.Poland, WeaponType.TwoHandedSword));
        }

        public void AddWeapons(List<IWeapon> weapons)
        {
            Stock.AddRange(weapons);
        }
        
        public void RemoveWeapons(List<IWeapon> weapons)
        {
            weapons.ForEach(weapon => Stock.Remove(weapon));
        }

        public List<IWeapon> GetWeaponsOfType(string name)
        {
            return Stock.FindAll(weapon => weapon.Name == name);
        }

        public List<IWeapon> GetWeaponsOfOrigin(CountryOfOrigin origin)
        {
            return Stock.FindAll(weapon => weapon.Origin == origin);
        }

        public List<IWeapon> GetWeaponsByID(List<Guid> Ids)
        {
            List<IWeapon> weapons = new List<IWeapon>();
            foreach (Guid guid in Ids) 
            {
                List<IWeapon> tmp = Stock.FindAll(x => x.Id == guid);
                if (tmp.Count > 0)
                    weapons.AddRange(tmp);
            }

            return weapons;
        }
    }
}
