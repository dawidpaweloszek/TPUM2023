using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data;

namespace LogicTest
{
    internal class WarehouseTest : IWarehouse
    {
        public List<IWeapon> Stock { get; }

        public event EventHandler<PriceChangeEventArgs> PriceChange;

        public WarehouseTest() 
        { 
            Stock = new List<IWeapon>();
        }

        public void AddWeapons(List<IWeapon> weapons)
        {
            Stock.AddRange(weapons);
        }

        public void ChangePrice(Guid id, float newPrice)
        {
            IWeapon weapon = Stock.Find(x => x.Id.Equals(id));

            if (weapon != null)
                return;

            if (Math.Abs(newPrice - weapon.Price) < 0.01f)
                return;

            weapon.Price = newPrice;
            OnPriceChanged(weapon.Id, weapon.Price);
        }

        public List<IWeapon> GetWeaponsByID(List<Guid> Ids)
        {
            List<IWeapon> weapons = new List<IWeapon>();
            foreach (Guid guid in Ids)
            {
                List<IWeapon> tmp = Stock.FindAll(x => x.Id == guid);
                if (tmp.Count > 0)
                    weapons.AddRange(tmp);
            }

            return weapons;
        }

        public List<IWeapon> GetWeaponsOfOrigin(CountryOfOrigin origin)
        {
            return Stock.FindAll(weapon => weapon.Origin == origin);
        }

        public List<IWeapon> GetWeaponsOfType(WeaponType type)
        {
            return Stock.FindAll(weapon => weapon.Type == type);
        }

        public void RemoveWeapons(List<IWeapon> weapons)
        {
            weapons.ForEach(weapon => Stock.Remove(weapon));
        }

        private void OnPriceChanged(Guid id, float price)
        {
            EventHandler<PriceChangeEventArgs> handler = PriceChange;
            handler?.Invoke(this, new PriceChangeEventArgs(id, price));
        }
        public Task RequestWeaponsUpdate()
        {
            throw new NotImplementedException();
        }
        public Task SendAsync(string message)
        {
            throw new NotImplementedException();
        }
        public IDisposable Subscribe(IObserver<IWeapon> observer)
        {
            throw new NotImplementedException();
        }
    }
}
