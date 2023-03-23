using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class LogicLayer
    {
        public IShop Shop { get; private set; }

        public static LogicLayer Create()
        {
            return new LogicLayer(DataLayer.Create());
        }

        public LogicLayer(DataLayer data)
        {
            Shop = new Shop(data.Warehouse);
        }
    }
}
