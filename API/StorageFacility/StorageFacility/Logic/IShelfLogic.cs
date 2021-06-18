using StorageFacility.Classes;
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
        void AddProductToShelf(string rackName, string shelfName, string barcode);
        void AddProductAmount(string rackName, string shelfName, string barcode, int amount);
        void RemoveProductAmount(string rackName, string shelfName, string barcode, int amount);
        List<Shelf> GetShelves();
    }
}
