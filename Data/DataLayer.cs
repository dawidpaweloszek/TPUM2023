using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DataLayer
    {
        public IWarehouse Warehouse { get; private set; }

        public static DataLayer Create()
        {
            return new DataLayer();
        }

        public DataLayer() 
        {
            Warehouse = new Warehouse();
        }
    }
}
