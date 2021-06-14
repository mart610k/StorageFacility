﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StorageFacility.Classes
{
    public interface IObjectFactory
    {
        IAuthService GetAuthService();

        IRackService GetRackService(IDatabaseConnection databaseConnection);

        IDatabaseConnection GetDatabaseConnection(string host, int port, string databaseName, string username, string password);

        IDatabaseConnection GetDatabaseConnectionFromFile(string filePath);

        IFileAccess GetFileAccess();

        IShelfService GetShelfService(IDatabaseConnection databaseConnection);

    }
}
