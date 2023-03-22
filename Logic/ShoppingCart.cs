using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    internal class ShoppingCart : IShoppingCart
    {
        private List<WeaponDTO> weapons;
        public float ShoppingCartValue { get; private set; }

        public ShoppingCart()
        {
            weapons = new List<WeaponDTO>();
            ShoppingCartValue = 0;
        }

        public bool AddWeapon(WeaponDTO weapon)
        {
            weapons.Add(weapon);
            ShoppingCartValue += weapon.Price;
            return true;
        }

        public bool RemoveWeapon(WeaponDTO weapon)
        {
            weapons.Remove(weapon);
            ShoppingCartValue -= weapon.Price;
            return true;
        }
    }
}
