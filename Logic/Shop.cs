using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace Logic
{
    internal class Shop : IShop, IObserver<IWeapon>
    {
        public event EventHandler<PriceChangeEventArgs> PriceChanged;
        public event EventHandler<IWeaponDTO> OnWeaponChanged;

        private IWarehouse warehouse;
        private ISpecialOffer specialOffer;
        private IDisposable unsubscriber;

        public Shop(IWarehouse warehouse)
        {
            this.warehouse = warehouse;
            specialOffer = new SpecialOffer(warehouse);
            warehouse.PriceChange += OnPriceChanged;
            warehouse.Subscribe(this);
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

        private void OnPriceChanged(object sender, Data.PriceChangeEventArgs e) 
        {
            EventHandler<PriceChangeEventArgs> handler = PriceChanged;
            handler?.Invoke(this, new Logic.PriceChangeEventArgs(e.Id, e.Price));
        }

        public async Task SendMessageAsync(string mesg)
        {
            await warehouse.SendAsync(mesg);
        }

        public void OnCompleted()
        {
            this.Unsunscribe();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(IWeapon value)
        {
            var dto = new WeaponDTO();
            dto.Price = value.Price;
            dto.Id = value.Id;
            dto.Name = value.Name;
            dto.Type = value.Type.ToString();
            dto.Origin = value.Origin.ToString();

            OnWeaponChanged?.Invoke(this, dto);
        }

        private void Unsunscribe()
        {
            unsubscriber.Dispose();
        }
    }
}
