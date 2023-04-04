using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    internal class Warehouse : IWarehouse
    {
        public event EventHandler<PriceChangeEventArgs> PriceChange;
        private bool waitingForStockUpdate;
        private List<IObserver<IWeapon>> observers;

        public List<IWeapon> Stock { get; private set; }

        public Warehouse() 
        { 
            Stock = new List<IWeapon>();
            observers = new List<IObserver<IWeapon>>();

            waitingForStockUpdate = false;

            // TODO: @Ignacy - temporary we can add weapons here
            Stock.Add(new Weapon("Toporek fantastyczny", 200f, CountryOfOrigin.China, WeaponType.BattleAxe));
            Stock.Add(new Weapon("Młotek fantastyczny ", 300.5f, CountryOfOrigin.Germany, WeaponType.WarHammer));
            Stock.Add(new Weapon("Katana fajowska     ", 1000f, CountryOfOrigin.Japan, WeaponType.Katana));
            Stock.Add(new Weapon("Miecz taki polski      ", 250f, CountryOfOrigin.Poland, WeaponType.TwoHandedSword));
            WebSocketClient.OnConnected += Connected;

        }

        public void AddWeapons(List<IWeapon> weapons)
        {
            foreach(var weapon in weapons) 
            {
                AddWeapon(weapon);
            }
        }
        
        public void AddWeapon(IWeapon weapon)
        {
            Stock.Add(weapon);
            foreach(var observer in observers)
            {
                observer.OnNext(weapon);
            }
        }
        public void RemoveWeapons(List<IWeapon> weapons)
        {
            weapons.ForEach(weapon => Stock.Remove(weapon));
        }

        public List<IWeapon> GetWeaponsOfType(WeaponType type)
        {
            return Stock.FindAll(weapon => weapon.Type == type);
        }

        public List<IWeapon> GetWeaponsOfOrigin(CountryOfOrigin origin)
        {
            return Stock.FindAll(weapon => weapon.Origin == origin);
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

        private void OnPriceChanged(Guid id, float price) 
        {
            EventHandler<PriceChangeEventArgs> handler = PriceChange;
            handler?.Invoke(this, new PriceChangeEventArgs(id, price));
        }

        public async Task SendAsync(string mesg)
        {
            waitingForStockUpdate = true;
            await WebSocketClient.CurrentConnection.SendAsync(mesg);
            //while (waitingForStockUpdate) { }
        }

        public async Task RequestWeaponsUpdate()
        {
            await WebSocketClient.CurrentConnection.SendAsync("RequestAll");
        }

        private async void ParseMessage(string message)
        {
            if (message.Contains("UpdateAll"))
            {
                var json = message.Substring("UpdateAll".Length);
                var weapons = Serializer.JSONToWarehouse(json);
                foreach (var weapon in weapons) 
                { 
                    AddWeapon(weapon);
                }
                waitingForStockUpdate = false;
            }
        }
        private async void Connected()
        {
            WebSocketClient.CurrentConnection.OnMessage = ParseMessage;
            await RequestWeaponsUpdate();
        }

        public IDisposable Subscribe(IObserver<IWeapon> observer)
        {
            if (!observers.Contains(observer))
                observers.Add(observer);
            return new Unsubscriber(observers, observer);
        }

        private class Unsubscriber : IDisposable
        {
            private List<IObserver<IWeapon>> _observers;
            private IObserver<IWeapon> _observer;

            public Unsubscriber(List<IObserver<IWeapon>> observers, IObserver<IWeapon> observer)
            {
                this._observers = observers;
                this._observer = observer;
            }

            public void Dispose()
            {
                if (_observer != null && _observers.Contains(_observer))
                    _observers.Remove(_observer);
            }
        }
    }
}
