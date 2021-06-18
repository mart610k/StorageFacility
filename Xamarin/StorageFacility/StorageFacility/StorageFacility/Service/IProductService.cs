using StorageFacility.Class;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StorageFacility.Service
{
    interface IProductService
    {
        Task<bool> CreateProduct(string name, string barcode);

        Task<List<Product>> GetProducts();
    }
}