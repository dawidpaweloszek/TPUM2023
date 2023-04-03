using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicServer
{
    internal class ShoppingCart : IShoppingCart
    {
        private List<IWeaponDTO> weapons;
        public float ShoppingCartValue { get; private set; }

        public ShoppingCart()
        {
            weapons = new List<IWeaponDTO>();
            ShoppingCartValue = 0;
        }

        public bool AddWeapon(IWeaponDTO weapon)
        {
            weapons.Add(weapon);
            ShoppingCartValue += weapon.Price;
            return true;
        }

        public bool RemoveWeapon(IWeaponDTO weapon)
        {
            weapons.Remove(weapon);
            ShoppingCartValue -= weapon.Price;
            return true;
        }
    }
}
