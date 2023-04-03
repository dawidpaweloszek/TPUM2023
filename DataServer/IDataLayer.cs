using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataServer
{
    public interface IDataLayer
    {
        IWarehouse Warehouse { get; set; }
        static IDataLayer Create(IWarehouse warehouse = default)
        {
            return new DataLayer(warehouse);
        }
    }
}
