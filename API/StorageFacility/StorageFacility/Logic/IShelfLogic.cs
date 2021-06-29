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
        /// <summary>
        /// Registers a shelf on the given rack
        /// </summary>
        /// <param name="name">the shelf name</param>
        /// <param name="rackName">the rack name</param>
        void RegisterShelf(string name, string rackName);

        /// <summary>
        /// Gets the Shelves and the amount contained of the searched product
        /// </summary>
        /// <param name="productID">the product ID</param>
        /// <returns>the shelves and the products on the different Racks</returns>
        List<ShelfProductAmount> GetShelvesContainingProductByID(string username,string productID);
        
        /// <summary>
        /// Adds a product to the shelf
        /// </summary>
        /// <param name="rackName">the rack name</param>
        /// <param name="shelfName">the shelf name</param>
        /// <param name="barcode">product barcode</param>
        void AddProductToShelf(string rackName, string shelfName, string barcode);
        
        /// <summary>
        /// Adds a product amount to the product on the shelf
        /// </summary>
        /// <param name="rackName">the Rack name</param>
        /// <param name="shelfName">The shelf name</param>
        /// <param name="barcode">the product barcode</param>
        /// <param name="amount">The amount to add</param>
        void AddProductAmount(string rackName, string shelfName, string barcode, int amount);

        /// <summary>
        /// Adds a product amount to the product on the shelf
        /// </summary>
        /// <param name="rackName">the Rack name</param>
        /// <param name="shelfName">The shelf name</param>
        /// <param name="barcode">the product barcode</param>
        /// <param name="amount">The amount to remove</param>
        void RemoveProductAmount(string rackName, string shelfName, string barcode, int amount);
        
        /// <summary>
        /// Gets the all the shelves
        /// </summary>
        /// <returns>A list of each of the shelves</returns>
        List<Shelf> GetShelves();

        /// <summary>
        /// Gets the product amount on the different shelves
        /// </summary>
        /// <returns>a list for the products located on the shelves</returns>
        List<ShelfProductAmount> GetProductAmount();
    }
}
