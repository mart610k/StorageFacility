using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StorageFacility.Service;

namespace StorageFacility.Classes
{
    public class ObjectFactory : IObjectFactory
    {
        public IAuthService GetAuthService()
        {
            return new AuthService();
        }

        public IDatabaseConnection GetDatabaseConnection(string host, int port, string databaseName, string username, string password)
        {
            return new MySQLConnection(host, port, databaseName, username, password);
        }

        public IDatabaseConnection GetDatabaseConnectionFromFile(string filePath)
        {
            IFileAccess fileAccess = GetFileAccess();
            string fileContent = fileAccess.GetFileContent(filePath);
            string[] settings = fileContent.Split(",");
            Dictionary<string, string> settingsKeyValues = new Dictionary<string, string>();
            foreach (string item in settings)
            {
                string[] temp = item.Split("=");

                settingsKeyValues.Add(temp[0], temp[1]);
            }

            return new MySQLConnection(
                   settingsKeyValues.GetValueOrDefault("host", "localhost"),
                   int.Parse(settingsKeyValues.GetValueOrDefault("port", "3306")),
                   settingsKeyValues.GetValueOrDefault("databaseName", "database"),
                   settingsKeyValues.GetValueOrDefault("username", "username"),
                   settingsKeyValues.GetValueOrDefault("password", "password")
                   );
        }

        public IBarcodeVerifier GetEAN13BarcodeVerifier()
        {
            return new EAN13BarcodeVerifier();
        }

        public IFileAccess GetFileAccess()
        {
            return new FileAccess();
        }

        public IProductService GetProductService(IDatabaseConnection databaseConnection)
        {
            return new ProductService(databaseConnection);
        }

        public IRackService GetRackService(IDatabaseConnection databaseConnection)
        {
            return new RackService(databaseConnection);
        }

        public IShelfService GetShelfService(IDatabaseConnection databaseConnection)
        {
            return new ShelfService(databaseConnection);
        }
    }
}
