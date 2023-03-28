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
        public ObservableCollection<WeaponPresentation> Weapons { get; set; }
        private IShop Shop { get; set; }

        public ShoppingCart(ObservableCollection<WeaponPresentation> weapons, IShop shop)
        {
            Weapons = weapons;
            Shop = shop;
        }

        public void Add(WeaponPresentation weapon)
        {
            Weapons.Add(weapon);
        }

        public float Sum()
        {
            float res = 0f;
            foreach (WeaponPresentation weapon in Weapons)
            {
                res += weapon.Price;
            }

            return res;
        }

        public bool Buy()
        {
            List<WeaponDTO> shoppingList = new List<WeaponDTO>();


            foreach (WeaponPresentation weaponPresentation in Weapons)
            {
                shoppingList.Add(Shop.GetWeapons().FirstOrDefault(x => x.Id == weaponPresentation.Id));
            }

            bool res = Shop.Sell(shoppingList);
            if (res)
            {
                Weapons.Clear();
            }

            return res;
        }
    }
}
