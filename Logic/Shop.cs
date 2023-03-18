using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace Logic
{
    internal class Shop
    {
        private IWarehouse warehouse;

        public Shop(IWarehouse warehouse)
        {
            this.warehouse = warehouse;
        }

        // smth to do within the scope of the shop
        // so for the testing purpose i've used:
        public void RemoveItems(List<Vegetable> vegetables) 
        {
            warehouse.RemoveVeggies(vegetables);
        }
    }


}
