﻿using System;
using System.Collections.Generic;

namespace DataServer
{
    public interface IWarehouse
    {
        public event EventHandler<PriceChangeEventArgs> PriceChange;

        public List<IWeapon> Stock { get; }
        public void AddWeapons(List<IWeapon> weapons);
        public void RemoveWeapons(List<IWeapon> weapons);
        public List<IWeapon> GetWeaponsOfType(WeaponType type);
        public List<IWeapon> GetWeaponsOfOrigin(CountryOfOrigin origin);
        public List<IWeapon> GetWeaponsByID(List<Guid> Ids);
        public void ChangePrice(Guid id, float newPrice);
    }
}
