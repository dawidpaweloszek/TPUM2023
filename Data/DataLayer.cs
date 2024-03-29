﻿using System;
using System.Collections.Generic;
using System.Linq;
//using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IDataLayer
    {
        public IWarehouse Warehouse { get; set; }

        public static IDataLayer Create(IWarehouse warehouse = default)
        {
            return new DataLayer(warehouse);
        }
    }
    internal class DataLayer : IDataLayer
    {

        internal DataLayer(IWarehouse warehouse = default)
        {
            Warehouse = warehouse ?? new Warehouse();
        }

        public IWarehouse Warehouse { get; set; }

        public static IDataLayer Create(IWarehouse warehouse = default)
        {
            return new DataLayer();
        }
    }
}
