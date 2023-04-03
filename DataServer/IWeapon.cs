using System;

namespace DataServer
{
    public interface IWeapon
    {
        string Name { get; }
        float Price { get; set; }
        Guid Id { get; }
        CountryOfOrigin Origin { get; }
        WeaponType Type { get; }
    }
}
