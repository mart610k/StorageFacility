using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StorageFacility.Service
{
    /// <summary>
    /// Interface for the rack service
    /// </summary>
    public interface IRackService
    {
        /// <summary>
        /// Register rack on the system
        /// </summary>
        /// <param name="name">the rack name</param>
        /// <returns>if the rack was created</returns>
        bool Register(string name);
        
        
        /// <summary>
        /// Get a list of the racks on the system
        /// </summary>
        /// <returns>Racks on the system</returns>
        List<string> GetRacks();


    }
}
