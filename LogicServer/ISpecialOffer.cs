using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicServer
{
    public interface ISpecialOffer
    {
        Tuple<Guid, float> GetSpecialOffer();
    }
}
