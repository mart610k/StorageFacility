using StorageFacility.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StorageFacility.Factory
{
    public class DTOFactory : IDTOFactory
    {
        public Product GetProduct(string barcode, string productName)
        {
            return new Product(barcode, productName);
        }

        public Shelf GetShelf(string shelfName, string rackName)
        {
            return new Shelf(shelfName, rackName);
        }

        public ShelfProductAmount GetShelfProductAmount(Shelf shelf, Product product, byte amount)
        {
            return new ShelfProductAmount(shelf,product,amount);
        }
    }
}
