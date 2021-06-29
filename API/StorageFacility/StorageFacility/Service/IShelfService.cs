using StorageFacility.DTO;
﻿using StorageFacility.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StorageFacility.Service
{
    /// <summary>
    /// Interface for the shelf service
    /// </summary>
    public interface IShelfService
    {
        /// <summary>
        /// Register a shelf
        /// </summary>
        /// <param name="name">shelf name</param>
        /// <param name="rackName">Rack name</param>
        /// <returns>If successful</returns>
        bool Register(string name, string rackName);

        /// <summary>
        /// Gets a list of shelves containing the product
        /// </summary>
        /// <param name="productID">the product id</param>
        /// <returns>List of the products on the different shelves</returns>
        List<ShelfProductAmount> GetShelvesContainingProductByID(string productID);

        /// <summary>
        /// Adds a product to a shelf
        /// </summary>
        /// <param name="rackName">rack name</param>
        /// <param name="shelfName">shelf name</param>
        /// <param name="barcode">Product barcode</param>
        /// <returns>if it was successfull</returns>
        bool AddProductToShelf(string rackName, string shelfName, string barcode);
        
        /// <summary>
        /// Adds a product amount to the product on the shelf
        /// </summary>
        /// <param name="rackName"></param>
        /// <param name="shelfName"></param>
        /// <param name="barcode"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        bool AddProductAmount(string rackName, string shelfName, string barcode, int amount);

        /// <summary>
        /// Removes a product amount from the product on the shelf
        /// </summary>
        /// <param name="rackName"></param>
        /// <param name="shelfName"></param>
        /// <param name="barcode"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        bool RemoveProductAmount(string rackName, string shelfName, string barcode, int amount);

        /// <summary>
        /// Gets the shelves located on the racks
        /// </summary>
        /// <returns></returns>
        List<Shelf> GetShelves();

        /// <summary>
        /// Gets a full list of products and their amount throughout the system
        /// </summary>
        /// <returns></returns>
        List<ShelfProductAmount> GetShelfProductAmounts();
    }
}
