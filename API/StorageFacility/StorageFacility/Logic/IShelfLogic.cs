using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StorageFacility.Logic
{
    public interface IShelfLogic
    {
        void RegisterShelf(string name, string rackName);
    }
}
