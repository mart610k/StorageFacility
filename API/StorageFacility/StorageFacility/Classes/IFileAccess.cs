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
        /// <summary>
        /// reads the file from path
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        string GetFileContent(string path);

        /// <summary>
        /// Get the current work directory
        /// </summary>
        /// <returns></returns>
        string GetCurrentWorkingDirectory();
    }
}
