using System;
using System.Collections.Generic;
using Logic;
using System.Threading.Tasks;

namespace PresentationModel
{
    internal class WarehousePresentation : IWarehousePresentation
    {
        #region public

        public event EventHandler<PriceChangeEventArgs> PriceChanged;
        public event EventHandler<WeaponPresentation> WeaponChanged;
        public event EventHandler<WeaponPresentation> WeaponRemoved;
        public event EventHandler<List<WeaponPresentation>> TransactionSucceeded;
        public event EventHandler TransactionFailed;

        public WarehousePresentation(IShop shop)
        {
            Shop = shop;
            Shop.PriceChanged += OnPriceChanged;
            Shop.OnWeaponChanged += OnWeaponChanged;
            Shop.TransactionFailed += OnTransactionFailed;
            Shop.OnWeaponRemoved += OnWeaponRemoved;
            Shop.TransactionSucceeded += OnTransactionSucceeded;
            ConnectionService = ServiceFactory.CreateConnectionService;
            ConnectionService.ConnectionLogger += ConnectionLogger;
        }

        public List<WeaponPresentation> GetWeapons()
        {
            List<WeaponPresentation> weapons = new List<WeaponPresentation>();
            foreach (IWeaponDTO weapon in Shop.GetWeapons())
            {
                weapons.Add(new WeaponPresentation(weapon.Name, weapon.Price, weapon.Id, weapon.Origin, weapon.Type));
            }
            return weapons;
        }

        public async Task SendMessageAsync(string mesg)
        {
            Shop.SendMessageAsync(mesg);
        }
        
        public Task<bool> Connect(Uri uri)
        {
            return ConnectionService.Connect(uri);
        }

        public async Task Disconnect()
        {
            await ConnectionService.Disconnect();
        }

        public bool IsConnected()
        {
            return ConnectionService.Connected;
        }

        #endregion public

        #region private

        private void ConnectionLogger(string mesg)
        {
            Console.WriteLine(mesg);
        }

        private void OnWeaponRemoved(object? sender, IWeaponDTO e)
        {
            EventHandler<WeaponPresentation> handler = WeaponRemoved;
            WeaponPresentation Weapon = new WeaponPresentation(e.Name, e.Price, e.Id, e.Origin, e.Type);
            handler?.Invoke(this, Weapon);
        }

        private void OnTransactionSucceeded(object? sender, List<IWeaponDTO> e)
        {
            EventHandler<List<WeaponPresentation>> handler = TransactionSucceeded;
            List<WeaponPresentation> soldWeaponPresentations = new List<WeaponPresentation>();
            foreach (IWeaponDTO weaponDTO in e)
            {
                WeaponPresentation WeaponPresentation = new WeaponPresentation(weaponDTO.Name, weaponDTO.Price, weaponDTO.Id,
                    weaponDTO.Origin, weaponDTO.Type);
                soldWeaponPresentations.Add(WeaponPresentation);
            }

            handler?.Invoke(this, soldWeaponPresentations);
        }

        private void OnTransactionFailed(object? sender, EventArgs e)
        {
            EventHandler handler = TransactionFailed;
            handler?.Invoke(this, e);
        }

        private void OnWeaponChanged(object? sender, IWeaponDTO e)
        {
            EventHandler<WeaponPresentation> handler = WeaponChanged;
            WeaponPresentation weapon = new WeaponPresentation(e.Name, e.Price, e.Id, e.Origin, e.Type);
            handler?.Invoke(this, weapon);
        }

        private void OnPriceChanged(object sender, Logic.PriceChangeEventArgs e)
        {
            EventHandler<PresentationModel.PriceChangeEventArgs> handler = PriceChanged;
            handler?.Invoke(this, new PresentationModel.PriceChangeEventArgs(e.Id, e.Price));
        }

        private IShop Shop { get; set; }
        private IConnectionService ConnectionService;

        #endregion private
    }
}