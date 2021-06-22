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
        bool Register(ulong barcode, string name);
        List<Product> GetProducts();
    }
}
