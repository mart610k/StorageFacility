using StorageFacility.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StorageFacility.Logic
{
    public class RackLogic : IRackLogic
    {
        IObjectFactory objectFactory = new ObjectFactory();

        public List<string> GetRacks()
        {
            IAuthService authService = objectFactory.GetAuthService();
            IFileAccess fileAccess = objectFactory.GetFileAccess();
            string configFilePath = fileAccess.GetCurrentWorkingDirectory() + "\\config.txt";
            IDatabaseConnection databaseConnection = objectFactory.GetDatabaseConnectionFromFile(configFilePath);
            IRackService rackService = objectFactory.GetRackService(databaseConnection);

            if (authService.UserAllowed(""))
            {
                return rackService.GetRacks();
            }
            return null;
        }

        public void RegisterRack(string rackname)
        {
            IAuthService authService = objectFactory.GetAuthService();
            IFileAccess fileAccess = objectFactory.GetFileAccess();
            string configFilePath = fileAccess.GetCurrentWorkingDirectory() + "\\config.txt";
            IDatabaseConnection databaseConnection = objectFactory.GetDatabaseConnectionFromFile(configFilePath);
            IRackService rackService = objectFactory.GetRackService(databaseConnection);

            if (authService.UserAllowed(""))
            {
                rackService.Register(rackname);
            }
            return;
        }
    }
}
