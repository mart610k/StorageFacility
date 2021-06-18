using StorageFacility.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StorageFacility.DTO;

namespace StorageFacility.Service
{
    public interface IProductService
    {
        bool Register(ulong barcode, string name);
        List<Product> GetProducts();
    }
}
