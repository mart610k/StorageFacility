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
        bool Register(string name);
        List<string> GetRacks();
    }
}
