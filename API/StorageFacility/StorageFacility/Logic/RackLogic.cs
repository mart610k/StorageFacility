using StorageFacility.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StorageFacility.Service;

namespace StorageFacility.Logic
{
    public class RackLogic : IRackLogic
    {
        // Initiating the Factory
        IObjectFactory objectFactory = new ObjectFactory();

        /// <summary>
        /// Gets all Racks
        /// Uses Factory to get the necesarry Services
        /// Uses RackService to get all Racks
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Registers a Rack, based on the input
        /// Uses Factory to get the necesarry services 
        /// Uses RackService to register the Rack
        /// </summary>
        /// <param name="rackname"></param>
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
