using StorageFacility.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StorageFacility.Factory
{
    public interface IDTOFactory
    {
        Shelf GetShelf(string shelfName, string rackName);

        Product GetProduct(string barcode, string productName);

        ShelfProductAmount GetShelfProductAmount(Shelf shelf, Product product,byte amount);
    }
}
