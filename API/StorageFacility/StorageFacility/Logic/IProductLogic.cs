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
        void RegisterProduct(string username, string barcode, string name);
        List<Product> GetProducts();
    }
}
