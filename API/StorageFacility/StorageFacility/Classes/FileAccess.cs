using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace StorageFacility.Classes
{
    public class FileAccess : IFileAccess
    {
        public string GetCurrentWorkingDirectory()
        {
            return Directory.GetCurrentDirectory();
        }

        public string GetFileContent(string path)
        {
            return File.ReadAllText(path);
        }
    }
}
