using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StorageFacility.Classes
{
    public interface IProductService
    {
        bool Register(ulong barcode, string name);
    }
}
