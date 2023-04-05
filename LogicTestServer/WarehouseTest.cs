using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataServer;

namespace LogicTestServer
{
    internal class WarehouseTest : IWarehouse
    {
        public WarehouseTest()
        {
            Stock = new List<IWeapon>();
        }

        public event EventHandler<PriceChangeEventArgs> PriceChange;
        public List<IWeapon> Stock { get; }

        public void RemoveWeapons(List<IWeapon> weapons)
        {
            weapons.ForEach(x => Stock.Remove(x));
        }

        public void AddWeapons(List<IWeapon> weapons)
        {
            Stock.AddRange(weapons);
        }

        public List<IWeapon> GetWeaponsOfType(WeaponType type)
        {
            return Stock.FindAll(x => x.Type == type);
        }

        public List<IWeapon> GetWeaponsOfOrigin(CountryOfOrigin origin)
        {
            return Stock.FindAll(x => x.Origin == origin);
        }

        public List<IWeapon> GetWeaponsByID(List<Guid> IDs)
        {
            List<IWeapon> weapons = new List<IWeapon>();
            foreach (Guid guid in IDs)
            {
                List<IWeapon> temp = Stock.FindAll(x => x.Id == guid);
                if (temp.Count > 0)
                    weapons.AddRange(temp);
            }

            return weapons;
        }

        public void ChangePrice(Guid id, float newPrice)
        {
            IWeapon weapon = Stock.Find(x => x.Id.Equals(id));

            if (weapon == null)
                return;
            if (Math.Abs(newPrice - weapon.Price) < 0.01f)
                return;
            weapon.Price = newPrice;
            OnPriceChanged(weapon.Id, weapon.Price);
        }

        private void OnPriceChanged(Guid id, float price)
        {
            EventHandler<PriceChangeEventArgs> handler = PriceChange;
            handler?.Invoke(this, new PriceChangeEventArgs(id, price));
        }
    }
}