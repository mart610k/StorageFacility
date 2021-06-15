using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StorageFacility.Logic
{
    public interface IProductLogic
    {
        void RegisterProduct(string username, string barcode, string name);
    }
}
