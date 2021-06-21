using System.Collections.Generic;
using System.Threading.Tasks;
using StorageFacility.DTO;

namespace StorageFacility.Service
{
    interface IProductService
    {
        Task<bool> CreateProduct(string name, string barcode);

        Task<List<Product>> GetProducts();
    }
}