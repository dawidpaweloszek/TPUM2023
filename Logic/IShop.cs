using Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Logic
{
    public interface IShop
    {
        public event EventHandler<PriceChangeEventArgs> PriceChanged;
        public event EventHandler<IWeaponDTO> OnWeaponChanged;
        public event EventHandler<IWeaponDTO> OnWeaponRemoved;
        public event EventHandler TransactionFailed;
        public event EventHandler<List<IWeaponDTO>> TransactionSucceeded;

        List<IWeaponDTO> GetWeapons();
        public Task Sell(List<IWeaponDTO> weapons);
        public Task SendMessageAsync(string mesg);
    }
}
