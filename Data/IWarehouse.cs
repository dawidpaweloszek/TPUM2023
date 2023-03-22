using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IWarehouse
    {
        void AddWeapons(List<Weapon> weapons);
        void RemoveWeapons(List<Weapon> weapons);
        List<Weapon> GetWeaponsOfType(string name);
        List<Weapon> GetWeaponsOfOrigin(CountryOfOrigin origin);
    }
}
