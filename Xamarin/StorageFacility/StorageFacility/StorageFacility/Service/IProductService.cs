using System.Collections.Generic;
using System.Threading.Tasks;
using StorageFacility.DTO;

namespace StorageFacility.Service
{
    /// <summary>
    /// Interface responsible for providing methods to obtain Product realted information
    /// </summary>
    interface IProductService
    {
        /// <summary>
        /// Call the API responsible for creating a new Product
        /// </summary>
        /// <param name="name">Product Name</param>
        /// <param name="barcode">Product Barcode</param>
        /// <returns>product was created on the database</returns>
        Task<bool> CreateProduct(string name, string barcode);

        /// <summary>
        /// Gets a list of products from the API
        /// </summary>
        /// <returns>A list of products present on the database</returns>
        Task<List<Product>> GetProducts();
    }
}