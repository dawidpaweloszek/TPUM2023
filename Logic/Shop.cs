using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace Logic
{
    public class Shop : IShop
    {
        private IWarehouse warehouse;
        private IShoppingCart cart;

        public Shop(IWarehouse warehouse)
        {
            this.warehouse = warehouse;
            cart = new ShoppingCart();
        }

        public List<WeaponDTO> GetWeapons()
        {
            List<WeaponDTO> availableWeapons = new List<WeaponDTO>();

            foreach (IWeapon weapon in warehouse.Stock)
                availableWeapons.Add(new WeaponDTO
                {
                    Name = weapon.Name,
                    Price = weapon.Price,
                    Id = weapon.Id,
                    Type = weapon.Type.ToString(),
                    Origin = weapon.Origin.ToString()
                });

            return availableWeapons;
        }

        public bool Sell(List<WeaponDTO> weapons)
        {
            List<Guid> weaponIds = new List<Guid>();

            foreach (WeaponDTO weapon in weapons) 
                weaponIds.Add(weapon.Id);

            List<IWeapon> weaponsDataLayer = warehouse.GetWeaponsByID(weaponIds);

            warehouse.RemoveWeapons(weaponsDataLayer);

            return true;
        }
    }
}
