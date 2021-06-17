using System.Threading.Tasks;

namespace StorageFacility.Service
{
    interface IProductService
    {
        Task<bool> CreateProduct(string name, string barcode);
    }
}