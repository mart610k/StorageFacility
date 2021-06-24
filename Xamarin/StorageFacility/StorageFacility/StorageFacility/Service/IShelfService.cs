using StorageFacility.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StorageFacility.Service
{
    interface IShelfService
    {
        /// <summary>
        /// Calls the API for creating shelf.
        /// </summary>
        /// <param name="name">Shelf Name</param>
        /// <param name="rackName">Rack Name</param>
        /// <returns>If the request was successfull</returns>
        Task<bool> CreateShelf(string name, string rackName);
        
        /// <summary>
        /// Calls the API for getting a list of products based on the product barcode
        /// </summary>
        /// <param name="productBarcode">Product Barcode to search for</param>
        /// <returns>The shelves where the product is present on</returns>
        Task<List<ShelfProductAmount>> GetProductsFromBarcode(string productBarcode);
        
        /// <summary>
        /// Calls the API for adding product to shelf
        /// </summary>
        /// <param name="rackName">Rack Name</param>
        /// <param name="shelfName">Shelf Name</param>
        /// <param name="barcode">Product Barcode</param>
        /// <returns>If the request was sucessfull</returns>
        Task<bool> AddProductToShelf(string rackName, string shelfName, string barcode);
        
        /// <summary>
        /// Gets a list of shelves from the API
        /// </summary>
        /// <returns>A list of the shelves present on the API</returns>
        Task<List<Shelf>> GetShelves();

        /// <summary>
        /// Adds an amount to a product
        /// based on the inputs
        /// specifying the rack and shelf
        /// </summary>
        /// <param name="rackName"></param>
        /// <param name="shelfName"></param>
        /// <param name="barcode"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        Task<bool> AddProductAmount(string rackName, string shelfName, string barcode, int amount);

        Task<bool> RemoveProductAmount(string rackName, string shelfName, string barcode, int amount);

        Task<List<ShelfProductAmount>> GetProductAmount();
    }
}