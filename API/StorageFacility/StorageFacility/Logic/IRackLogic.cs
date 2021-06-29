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
        /// <summary>
        /// Register the rack in the database
        /// </summary>
        /// <param name="rackname">the rack name</param>
        void RegisterRack(string rackname);
        
        /// <summary>
        /// gets a list of the racks
        /// </summary>
        /// <returns>list of the racks</returns>
        List<string> GetRacks();

    }
}
