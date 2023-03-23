using System;
using System.Collections.Generic;
using System.Linq;
//using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    internal class DataLayer : IDataLayer
    {
        public IWarehouse Warehouse { get; set; }

        public static DataLayer Create()
        {
            return new DataLayer();
        }

        internal DataLayer() 
        {
            Warehouse = new Warehouse();
        }
    }
}
