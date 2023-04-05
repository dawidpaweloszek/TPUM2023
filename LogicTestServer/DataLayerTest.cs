using System.Collections.Generic;
using LogicTestServer;
using DataServer;

namespace LogicTestServer
{
    internal class DataLayerTest : IDataLayer
    {
        public IWarehouse Warehouse { get; set; }

        public DataLayerTest(IWarehouse warehouse)
        {
            Warehouse = warehouse ?? new WarehouseTestExample();
            //Warehouse = new WarehouseTestExample();
            //Warehouse.Stock.Clear();
        }

    }
}