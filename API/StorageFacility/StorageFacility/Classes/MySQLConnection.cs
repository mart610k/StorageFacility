using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StorageFacility.Classes
{
    public class MySQLConnection : IDatabaseConnection
    {
        private string host;

        private int port;

        private string databaseName;

        private string username;

        private string password;

        public MySQLConnection(string host, int port, string databaseName, string username,string password)
        {
            this.host = host;
            this.port = port;
            this.databaseName = databaseName;
            this.username = username;
            this.password = password;
        }

        public string GetConnectionString()
        {
            return string.Format("Server={0};Port={1};Database={2};Uid={3};Pwd={4};",host,port,databaseName,username,password);
        }
    }
}
