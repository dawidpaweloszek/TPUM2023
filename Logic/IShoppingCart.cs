using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public interface IShoppingCart
    {
        bool AddWeapon(WeaponDTO weapon);
        bool RemoveWeapon(WeaponDTO weapon);
    }
}
