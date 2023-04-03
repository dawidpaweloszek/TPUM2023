using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicServer
{
    public interface IWeaponDTO
    {
        public string Name { get; set; }
        public float Price { get; set; }
        public Guid Id { get; set; }
        public string Origin { get; set; }
        public string Type { get; set; }
    }
}
