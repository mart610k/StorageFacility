using StorageFacility.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StorageFacility.Service;

namespace StorageFacility.Logic
{
    public class ShelfLogic : IShelfLogic
    {
        IObjectFactory objectFactory = new ObjectFactory();
        public void RegisterShelf(string name, string rackName)
        {
            IAuthService authService = objectFactory.GetAuthService();
            IFileAccess fileAccess = objectFactory.GetFileAccess();
            string configFilePath = fileAccess.GetCurrentWorkingDirectory() + "\\config.txt";
            IDatabaseConnection databaseConnection = objectFactory.GetDatabaseConnectionFromFile(configFilePath);
            IShelfService shelfService = objectFactory.GetShelfService(databaseConnection);

            if (authService.UserAllowed(""))
            {
                shelfService.Register(name, rackName);
            }

        }
    }
}
