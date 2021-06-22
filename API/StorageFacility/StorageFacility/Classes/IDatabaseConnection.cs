using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StorageFacility.Classes
{
    /// <summary>
    /// Interface for database conn
    /// </summary>
    public interface IDatabaseConnection
    {
        string GetConnectionString();
    }
}
