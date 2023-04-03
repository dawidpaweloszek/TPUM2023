using DataServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicServer
{
    public class LogicLayer : ILogicLayer
    {
        public IShop Shop { get; private set; }
        private IDataLayer DataServer { get; }

        public LogicLayer(IDataLayer data)
        {
            DataServer = data;
            Shop = new Shop(DataServer.Warehouse);
        }
    }
}
