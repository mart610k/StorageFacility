using StorageFacility.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StorageFacility.DTO;

namespace StorageFacility.Logic
{
    /// <summary>
    /// Interface to Product Logic
    /// </summary>
    public interface IProductLogic
    {
        /// <summary>
        /// Registers a product in the system
        /// </summary>
        /// <param name="username">username</param>
        /// <param name="barcode">the product barcode</param>
        /// <param name="name">name of the product</param>
        void RegisterProduct(string username, string barcode, string name);
        
        
        /// <summary>
        /// Gets a list of products
        /// </summary>
        /// <returns>a list of the products</returns>
        List<Product> GetProducts();
    }
}
