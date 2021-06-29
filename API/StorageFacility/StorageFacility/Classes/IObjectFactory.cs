using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StorageFacility.Service;

namespace StorageFacility.Classes
{
    /// <summary>
    /// Interface for object factory
    /// </summary>
    public interface IObjectFactory
    {
        /// <summary>
        /// Gets a AuthService object
        /// </summary>
        /// <returns>AuthService to use</returns>
        IAuthService GetAuthService();

        /// <summary>
        /// Gets a RackService object
        /// </summary>
        /// <param name="databaseConnection">the connction settings to the database</param>
        /// <returns>RackService to use</returns>
        IRackService GetRackService(IDatabaseConnection databaseConnection);

        /// <summary>
        /// Gets a ProductService object
        /// </summary>
        /// <param name="databaseConnection">the connction settings to the database</param>
        /// <returns>ProductService to use</returns>
        IProductService GetProductService(IDatabaseConnection databaseConnection);

        /// <summary>
        /// Gets an instance of a connection for the database
        /// </summary>
        /// <param name="host">the database host ip or name</param>
        /// <param name="port">the port to connect to</param>
        /// <param name="databaseName">Name of the database</param>
        /// <param name="username">User name of the user to perform the actions on</param>
        /// <param name="password">password of the user</param>
        /// <returns>Instance of the database connection</returns>
        IDatabaseConnection GetDatabaseConnection(string host, int port, string databaseName, string username, string password);

        /// <summary>
        /// Reads the configuration from a config file
        /// </summary>
        /// <param name="filePath">file path of the config file</param>
        /// <returns>Connection based on the config file</returns>
        IDatabaseConnection GetDatabaseConnectionFromFile(string filePath);

        /// <summary>
        /// Gets a FileAccess object for accessing files on the host
        /// </summary>
        /// <returns>FileAccess to use</returns>
        IFileAccess GetFileAccess();

        /// <summary>
        /// Gets a EAN13 barcode verifier.
        /// </summary>
        /// <returns>An instance of the EAN13 barcode verifier</returns>
        IBarcodeVerifier GetEAN13BarcodeVerifier();

        /// <summary>
        /// Gets a ShelfService object
        /// </summary>
        /// <param name="databaseConnection">the connction settings to the database</param>
        /// <returns>ShelfService to use</returns>
        IShelfService GetShelfService(IDatabaseConnection databaseConnection);

    }
}
