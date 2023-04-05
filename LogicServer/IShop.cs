using DataServer;
using System;
using System.Collections.Generic;

namespace LogicServer
{
    public interface IShop
    {
        public event EventHandler<PriceChangeEventArgs> PriceChanged;

        List<IWeaponDTO> GetWeapons();
        bool Sell(List<IWeaponDTO> weapons);
    }
}
