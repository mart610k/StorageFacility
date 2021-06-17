using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StorageFacility.Classes
{
    public interface IRackService
    {
        bool Register(string name);
        List<string> GetRacks();
    }
}
