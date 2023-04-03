using DataServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicServer
{
    public interface ILogicLayer
    {
        public IShop Shop { get; }
        public static ILogicLayer Create(IDataLayer data = default(IDataLayer))
        {
            return new LogicLayer(data ?? IDataLayer.Create());
        }
    }
}
