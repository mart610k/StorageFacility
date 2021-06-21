using StorageFacility.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StorageFacility.Service
{
    interface IShelfService
    {
        Task<bool> CreateShelf(string name, string rackName);
        Task<List<ShelfProductAmount>> GetProductsFromBarcode(string productBarcode);
        Task<bool> AddProductToShelf(string rackName, string shelfName, string barcode);
        Task<List<Shelf>> GetShelves();
    }
}