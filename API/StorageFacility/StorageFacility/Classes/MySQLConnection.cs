using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StorageFacility.Classes
{
    public class MySQLConnection : IDatabaseConnection
    {
        // Properties
        private string host;
        private int port;
        private string databaseName;
        private string username;
        private string password;

        /// <summary>
        /// Constructor to manually set conn
        /// </summary>
        /// <param name="host"></param>
        /// <param name="port"></param>
        /// <param name="databaseName"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public MySQLConnection(string host, int port, string databaseName, string username,string password)
        {
            this.host = host;
            this.port = port;
            this.databaseName = databaseName;
            this.username = username;
            this.password = password;
        }

        /// <summary>
        /// Get's connection string
        /// </summary>
        /// <returns></returns>
        public string GetConnectionString()
        {
            return string.Format("Server={0};Port={1};Database={2};Uid={3};Pwd={4};",host,port,databaseName,username,password);
        }
    }
}
