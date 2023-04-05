using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataServer;

namespace LogicServer
{
    public class Shop : IShop
    {
        public event EventHandler<PriceChangeEventArgs> PriceChanged;

        private IWarehouse warehouse;
        private ISpecialOffer specialOffer;

        public Shop(IWarehouse warehouse)
        {
            this.warehouse = warehouse;
            specialOffer = new SpecialOffer(warehouse);
            warehouse.PriceChange += OnPriceChanged;
        }

        public List<IWeaponDTO> GetWeapons()
        {
            List<IWeaponDTO> availableWeapons = new List<IWeaponDTO>();

            foreach (IWeapon weapon in warehouse.Stock)
            {
                var dto = new WeaponDTO();
                dto.Name = weapon.Name;
                dto.Price = weapon.Price;
                dto.Id = weapon.Id;
                dto.Type = (int)weapon.Type;
                dto.Origin = (int)weapon.Origin;

                availableWeapons.Add(dto);
            }

            return availableWeapons;
        }

        public bool Sell(List<IWeaponDTO> weapons)
        {
            List<Guid> weaponIds = new List<Guid>();

            foreach (WeaponDTO weapon in weapons) 
                weaponIds.Add(weapon.Id);

            List<IWeapon> weaponsDataLayer = warehouse.GetWeaponsByID(weaponIds);
            if (weaponsDataLayer.Count != weapons.Count)
                return false;

            foreach (IWeaponDTO weaponDTO in weapons)
            {
                var warehouseWeapon = weaponsDataLayer.First(x => x.Id == weaponDTO.Id);
                if (warehouseWeapon.Price != weaponDTO.Price)
                    return false;
            }

            warehouse.RemoveWeapons(weaponsDataLayer);

            return true;
        }

        private void OnPriceChanged(object sender, DataServer.PriceChangeEventArgs e) 
        {
            EventHandler<PriceChangeEventArgs> handler = PriceChanged;
            handler?.Invoke(this, new LogicServer.PriceChangeEventArgs(e.Id, e.Price));
        }
    }
}
