using System;
using System.Collections.Generic;
using System.Text;
using Logic;
using System.Threading.Tasks;

namespace PresentationModel
{
    public class WarehousePresentation
    {
        private IShop Shop { get; set; }

        public WarehousePresentation(IShop shop)
        {
            Shop = shop;
            Shop.PriceChanged += OnPriceChanged;
            Shop.OnWeaponChanged += OnWeaponChanged;
            Shop.TransactionFailed += OnTransactionFailed;
            Shop.OnWeaponRemoved += OnWeaponRemoved;
            Shop.TransactionSucceeded += OnTransactionSucceeded;
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

        public event EventHandler<PresentationModel.PriceChangeEventArgs> PriceChanged;
        public event EventHandler<WeaponPresentation> WeaponChanged;
        public event EventHandler<WeaponPresentation> WeaponRemoved;
        public event EventHandler<List<WeaponPresentation>> TransactionSucceeded;
        public event EventHandler TransactionFailed;
    }
}