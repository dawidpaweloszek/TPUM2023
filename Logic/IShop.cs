using Data;
using System;
using System.Collections.Generic;

namespace Logic
{
    public interface IShop
    {
        public event EventHandler<PriceChangeEventArgs> PriceChanged;

        List<WeaponDTO> GetWeapons(bool onSale = true);
        bool Sell(List<WeaponDTO> weapons);
    }
}
