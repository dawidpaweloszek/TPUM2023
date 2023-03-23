using System;
using System.Collections.Generic;

namespace Data
{
    public interface IWarehouse
    {
        List<IWeapon> Stock { get; }
        void AddWeapons(List<IWeapon> weapons);
        void RemoveWeapons(List<IWeapon> weapons);
        List<IWeapon> GetWeaponsOfType(WeaponType type);
        List<IWeapon> GetWeaponsOfOrigin(CountryOfOrigin origin);
        List<IWeapon> GetWeaponsByID(List<Guid> Ids);
    }
}
