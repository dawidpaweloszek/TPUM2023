using System;
using System.Collections.Generic;
using System.Text;
using Logic;

namespace PresentationModel
{
    public class WarehousePresentation
    {
        private IShop Shop { get; set; }

        public WarehousePresentation(IShop shop)
        {
            Shop = shop;
        }
        public List<WeaponDTO> GetWeapons()
        {
            return Shop.GetWeapons();
        }
    }
}