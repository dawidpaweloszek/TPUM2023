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
        private ISpecialOffer specialOffer;

        public Shop(IWarehouse warehouse)
        {
            this.warehouse = warehouse;
            specialOffer = new SpecialOffer(warehouse);
        }

        public List<WeaponDTO> GetWeapons(bool onSale = true)
        {
            Tuple<Guid, float> sale = new Tuple<Guid, float>(Guid.Empty, 1f);
            if (onSale)
                sale = specialOffer.GetSpecialOffer();
                
            List<WeaponDTO> availableWeapons = new List<WeaponDTO>();

            foreach (IWeapon weapon in warehouse.Stock)
            {
                float price = weapon.Price;
                if (weapon.Id.Equals(sale.Item1))
                    price *= sale.Item2;

                availableWeapons.Add(new WeaponDTO
                {
                    Name = weapon.Name,
                    Price = price,
                    Id = weapon.Id,
                    Type = weapon.Type.ToString(),
                    Origin = weapon.Origin.ToString()
                });
            }

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
