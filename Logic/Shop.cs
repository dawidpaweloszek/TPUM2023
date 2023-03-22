using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace Logic
{
    public class Shop : IShop
    {
        private IWarehouse warehouse;

        public Shop(IWarehouse warehouse)
        {
            this.warehouse = warehouse;
        }

        public bool Sell(List<Weapon> weapons)
        {
            return false;
        }
    }
}
