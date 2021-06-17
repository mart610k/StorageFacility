using StorageFacility.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StorageFacility.Logic
{
    /// <summary>
    /// Interface for the Shelf Logic
    /// </summary>
    public interface IShelfLogic
    {
        void RegisterShelf(string name, string rackName);

        /// <summary>
        /// Gets the Shelves and the amount contained of the searched product
        /// </summary>
        /// <param name="productID">the product ID</param>
        /// <returns>the shelves and the products on the different Racks</returns>
        List<ShelfProductAmount> GetShelvesContainingProductByID(string username,string productID);
    }
}
