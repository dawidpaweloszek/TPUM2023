using System;
using LogicServer;

namespace PresentationServer
{
    internal class WeaponDTO : IWeaponDTO
    {
        public string Name { get; set; }
        public float Price { get; set; }
        public Guid Id { get; set; }
        public string Origin { get; set; }
        public string Type { get; set; }

        public WeaponDTO(string name, float price, Guid id, string origin, string type)
        {
            Name = name;
            Price = price;
            Id = id;
            Origin = origin;
            Type = type;
        }
    }
}
