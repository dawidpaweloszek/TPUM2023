using System;

namespace Data
{
    public interface IWeapon
    {
        public string Name { get; set; }
        public float Price { get; set; }
        public Guid Id { get; }
        public CountryOfOrigin Origin { get; set; }
        public WeaponType Type { get; set; }
    }
}
