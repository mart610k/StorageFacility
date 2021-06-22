using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StorageFacility.Classes
{
    /// <summary>
    /// Interface for File Access
    /// </summary>
    public interface IFileAccess
    {
        string GetFileContent(string path);
        string GetCurrentWorkingDirectory();
    }
}
