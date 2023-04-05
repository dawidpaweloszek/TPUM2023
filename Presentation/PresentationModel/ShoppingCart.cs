using Logic;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationModel
{
    internal class ShoppingCart : IShoppingCart
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

        public async Task Buy()
        {
            List<IWeaponDTO> shoppingList = new List<IWeaponDTO>();


            foreach (WeaponPresentation weaponPresentation in Weapons)
            {
                IWeaponDTO weapon = Shop.GetWeapons().FirstOrDefault(x => x.Id == weaponPresentation.Id);
                weapon.Price = weaponPresentation.Price;
                shoppingList.Add(weapon);
            }

            Task.Run(async () => await Shop.Sell(shoppingList));
            Weapons.Clear();
        }
    }
}
