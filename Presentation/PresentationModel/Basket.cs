using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationModel
{
    public class Basket
    {
        public List<WeaponDTO> Weapons { get; set; }

        public Basket(List<WeaponDTO> weapons)
        {
            Weapons = weapons;
        }

        public void Add(WeaponDTO weapon)
        {
            Weapons.Add(weapon);
        }
    }
}
