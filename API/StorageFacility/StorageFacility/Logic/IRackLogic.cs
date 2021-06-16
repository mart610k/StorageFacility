using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StorageFacility.Logic
{
    /// <summary>
    /// Interface to Rack Logic
    /// </summary>
    public interface IRackLogic
    {
        void RegisterRack(string rackname);
        List<string> GetRacks();
    }
}
