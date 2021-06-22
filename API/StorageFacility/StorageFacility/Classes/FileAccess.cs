using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace StorageFacility.Classes
{
    public class FileAccess : IFileAccess
    {
        /// <summary>
        /// Get the current work directory
        /// </summary>
        /// <returns></returns>
        public string GetCurrentWorkingDirectory()
        {
            return Directory.GetCurrentDirectory();
        }

        /// <summary>
        /// reads the file from path
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public string GetFileContent(string path)
        {
            return File.ReadAllText(path);
        }
    }
}
