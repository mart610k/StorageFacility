using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StorageFacility.Service
{
    public interface IShelfService
    {
        bool Register(string name, string rackName);
    }
}
