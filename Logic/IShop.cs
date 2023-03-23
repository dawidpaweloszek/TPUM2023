﻿using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public interface IShop
    {
        List<WeaponDTO> GetWeapons(bool onSale = true);
        bool Sell(List<WeaponDTO> weapons);
    }
}