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

        List<IWeaponDTO> GetWeapons(bool onSale = true);
        bool Sell(List<IWeaponDTO> weapons);
        public Task SendMessageAsync(string mesg);
    }
}
