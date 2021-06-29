using StorageFacility.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StorageFacility.DTO;

namespace StorageFacility.Service
{
    /// <summary>
    /// Interface for the Product Service
    /// </summary>
    public interface IProductService
    {
        /// <summary>
        /// Registers the product on the database
        /// </summary>
        /// <param name="barcode">the product barcode</param>
        /// <param name="name">product name</param>
        /// <returns>if the product were created</returns>
        bool Register(ulong barcode, string name);

        /// <summary>
        /// Gets a list of the products
        /// </summary>
        /// <returns>the product list</returns>
        List<Product> GetProducts();
    }
}
