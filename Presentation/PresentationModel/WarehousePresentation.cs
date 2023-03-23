using System;
using System.Collections.Generic;
using System.Text;
using Logic;

namespace PresentationModel
{
    public class WarehousePresentation
    {
        public IShop Shop { get; set; }

        public WarehousePresentation(IShop shop)
        {
            Shop = shop;
        }
    }
}