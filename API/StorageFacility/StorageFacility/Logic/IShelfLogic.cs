using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StorageFacility.Logic
{
    /// <summary>
    /// Interface for the Shelf Logic
    /// </summary>
    public interface IShelfLogic
    {
        void RegisterShelf(string name, string rackName);
    }
}
