using System.Collections.Generic;
using System.Threading.Tasks;

namespace StorageFacility.Service
{
    interface IRackService
    {
        Task<bool> CreateRack(string name);
        Task<List<string>> GetRacks();
    }
}