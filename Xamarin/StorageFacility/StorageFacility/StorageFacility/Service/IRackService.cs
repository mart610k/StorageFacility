using System.Collections.Generic;
using System.Threading.Tasks;

namespace StorageFacility.Service
{
    interface IRackService
    {
        /// <summary>
        /// Calls the API for creating a rack
        /// </summary>
        /// <param name="name">Rack name</param>
        /// <returns>Returns if the request was sucessfull</returns>
        Task<bool> CreateRack(string name);
        
        /// <summary>
        /// Gets the racks present on the program
        /// </summary>
        /// <returns>The racks present on the API</returns>
        Task<List<string>> GetRacks();
    }
}