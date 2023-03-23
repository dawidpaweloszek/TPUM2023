using Logic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationModel
{
    public class ShoppingCart
    {
        public ObservableCollection<WeaponDTO> Weapons { get; set; }
        private IShop Shop { get; set; }

        public ShoppingCart(ObservableCollection<WeaponDTO> weapons, IShop shop)
        {
            Weapons = weapons;
            Shop = shop;
        }

        public void Add(WeaponDTO weapon)
        {
            Weapons.Add(weapon);
        }

        public float Sum()
        {
            float res = 0f;
            foreach (WeaponDTO weapon in Weapons)
            {
                res += weapon.Price;
            }

            return res;
        }

        public bool Buy()
        {
            bool res = Shop.Sell(Weapons.ToList());
            if (res)
                Weapons.Clear();

            return res;
        }
    }
}
