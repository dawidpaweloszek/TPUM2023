using System.Collections;
using System.Collections.Generic;
using Data;

namespace LogicTest
{
    internal class DataLayerTest : IDataLayer
    {
        public IWarehouse Warehouse { get; set; }

        public DataLayerTest(IWarehouse warehouse)
        {
            Warehouse = warehouse ?? new WarehouseTest();
        }
    }
}
