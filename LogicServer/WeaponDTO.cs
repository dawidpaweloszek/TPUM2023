using DataServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicServer
{
    internal class WeaponDTO : IWeaponDTO
    {
        public string Name { get; set; }
        public float Price { get; set; }
        public Guid Id { get; set; }
        public int Origin { get; set; }
        public int Type { get; set; }
    }
}
