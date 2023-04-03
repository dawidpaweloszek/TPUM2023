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

        public List<IWeaponDTO> GetWeapons(bool onSale = true)
        {
            Tuple<Guid, float> sale = new Tuple<Guid, float>(Guid.Empty, 1f);
            if (onSale)
                sale = specialOffer.GetSpecialOffer();
                
            List<IWeaponDTO> availableWeapons = new List<IWeaponDTO>();

            foreach (IWeapon weapon in warehouse.Stock)
            {
                float price = weapon.Price;
                if (weapon.Id.Equals(sale.Item1))
                    price *= sale.Item2;

                var dto = new WeaponDTO();
                dto.Name = weapon.Name;
                dto.Price = price;
                dto.Id = weapon.Id;
                dto.Type = weapon.Type.ToString();
                dto.Origin = weapon.Origin.ToString();

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
