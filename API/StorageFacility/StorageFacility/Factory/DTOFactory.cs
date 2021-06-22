using StorageFacility.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StorageFacility.Factory
{
    public class DTOFactory : IDTOFactory
    {
        /// <summary>
        /// Get's a product based on Name and Barcode
        /// </summary>
        /// <param name="barcode"></param>
        /// <param name="productName"></param>
        /// <returns></returns>
        public Product GetProduct(string barcode, string productName)
        {
            return new Product(barcode, productName);
        }

        /// <summary>
        /// Gets a sehlf based on Shelfname and RackName
        /// </summary>
        /// <param name="shelfName"></param>
        /// <param name="rackName"></param>
        /// <returns></returns>
        public Shelf GetShelf(string shelfName, string rackName)
        {
            return new Shelf(shelfName, rackName);
        }

        /// <summary>
        /// Get's a Shelf with the amount of products of a specific type on it
        /// </summary>
        /// <param name="shelf"></param>
        /// <param name="product"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public ShelfProductAmount GetShelfProductAmount(Shelf shelf, Product product, byte amount)
        {
            return new ShelfProductAmount(shelf,product,amount);
        }
    }
}
