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
        private readonly object _dataLock = new object();

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
                availableWeapons.Add(new WeaponDTO { Price = weapon.Price, Id = weapon.Id, Name = weapon.Name, Type = (int)weapon.Type, Origin = (int)weapon.Origin });
            }

            return availableWeapons;
        }

        public bool Sell(List<IWeaponDTO> weaponsDTO)
        {
            lock (_dataLock)
            {
                List<Guid> guids = new List<Guid>();

                foreach(IWeaponDTO weaponDTO in weaponsDTO)
                {
                    guids.Add(weaponDTO.Id);
                }

                List<IWeapon> weapons = warehouse.GetWeaponsByID(guids);
                if (weapons.Count != weaponsDTO.Count) return false;

                foreach (IWeaponDTO weaponDTO in weaponsDTO)
                {
                    var warehouseWeapon = weapons.First( x => x.Id == weaponDTO.Id );
                    if (warehouseWeapon.Price != weaponDTO.Price) return false;
                }

                warehouse.RemoveWeapons(weapons);

                return true;
            }
        }

        private void OnPriceChanged(object sender, DataServer.PriceChangeEventArgs e) 
        {
            EventHandler<PriceChangeEventArgs> handler = PriceChanged;
            handler?.Invoke(this, new LogicServer.PriceChangeEventArgs(e.Id, e.Price));
        }
    }
}
