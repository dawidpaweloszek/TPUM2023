using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    internal interface IShoppingCart
    {
        bool AddWeapon(IWeaponDTO weapon);
        bool RemoveWeapon(IWeaponDTO weapon);
    }
}
