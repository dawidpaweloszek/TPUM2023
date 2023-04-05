using System;
using LogicServer;

namespace PresentationServer
{
    internal class WeaponDTO : IWeaponDTO
    {
        public string Name { get; set; }
        public float Price { get; set; }
        public Guid Id { get; set; }
        public int Origin { get; set; }
        public int Type { get; set; }

        public WeaponDTO(string name, float price, Guid id, int origin, int type)
        {
            Name = name;
            Price = price;
            Id = id;
            Origin = origin;
            Type = type;
        }
    }
}
