using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StorageFacility.Service;

namespace StorageFacility.Classes
{
    public class ObjectFactory : IObjectFactory
    {
        /// <summary>
        /// Get's Authservice
        /// </summary>
        /// <returns></returns>
        public IAuthService GetAuthService()
        {
            return new AuthService();
        }

        /// <summary>
        /// Gets Database conn
        /// </summary>
        /// <param name="host"></param>
        /// <param name="port"></param>
        /// <param name="databaseName"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public IDatabaseConnection GetDatabaseConnection(string host, int port, string databaseName, string username, string password)
        {
            return new MySQLConnection(host, port, databaseName, username, password);
        }

        /// <summary>
        /// Gets database conn from file
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
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

        /// <summary>
        /// gets barcode verifier
        /// </summary>
        /// <returns></returns>
        public IBarcodeVerifier GetEAN13BarcodeVerifier()
        {
            return new EAN13BarcodeVerifier();
        }

        /// <summary>
        /// gets file access
        /// </summary>
        /// <returns></returns>
        public IFileAccess GetFileAccess()
        {
            return new FileAccess();
        }

        /// <summary>
        /// gets product service
        /// </summary>
        /// <param name="databaseConnection"></param>
        /// <returns></returns>
        public IProductService GetProductService(IDatabaseConnection databaseConnection)
        {
            return new ProductService(databaseConnection);
        }

        /// <summary>
        /// gets rack service
        /// </summary>
        /// <param name="databaseConnection"></param>
        /// <returns></returns>
        public IRackService GetRackService(IDatabaseConnection databaseConnection)
        {
            return new RackService(databaseConnection);
        }

        /// <summary>
        /// gets shelf service
        /// </summary>
        /// <param name="databaseConnection"></param>
        /// <returns></returns>
        public IShelfService GetShelfService(IDatabaseConnection databaseConnection)
        {
            return new ShelfService(databaseConnection);
        }
    }
}
