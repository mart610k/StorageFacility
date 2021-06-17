using System.Threading.Tasks;

namespace StorageFacility.Service
{
    interface IShelfService
    {
        Task<bool> CreateShelf(string name, string rackName);
    }
}