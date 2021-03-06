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
        bool Register(string name, string rackName);
        List<ShelfProductAmount> GetShelvesContainingProductByID(string productID);
        bool AddProductToShelf(string rackName, string shelfName, string barcode);
        bool AddProductAmount(string rackName, string shelfName, string barcode, int amount);
        bool RemoveProductAmount(string rackName, string shelfName, string barcode, int amount);
        List<Shelf> GetShelves();
        List<ShelfProductAmount> GetShelfProductAmounts();
    }
}
