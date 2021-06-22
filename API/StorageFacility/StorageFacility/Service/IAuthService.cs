using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StorageFacility.Service
{
    /// <summary>
    /// Interface for the Authentication Service
    /// </summary>
    public interface IAuthService
    {
        bool UserAllowed(string name);

    }
}
