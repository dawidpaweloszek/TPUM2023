using System;

namespace Data
{
    public interface IWeapon
    {
        string Name { get; set; }
        float Price { get; set; }
        Guid Id { get; }
        CountryOfOrigin Origin { get; set; }
        WeaponType Type { get; set; }
    }
}
