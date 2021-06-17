using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StorageFacility.Classes;

namespace StorageFacility.Service
{
    public class ShelfService : IShelfService
    {
        private IDatabaseConnection databaseConnection;

        public ShelfService(IDatabaseConnection databaseConnection)
        {
            this.databaseConnection = databaseConnection;
        }

        public bool Register(string name, string rackName)
        {
            MySqlConnection conn = new MySqlConnection(databaseConnection.GetConnectionString());

            MySqlCommand comm = conn.CreateCommand();

            comm.CommandText = "INSERT INTO Shelf(`Name`, `Rack_Name`) Value (@name, @rackName);";

            comm.Parameters.AddWithValue("@name", name);
            comm.Parameters.AddWithValue("@rackName", rackName);

            try
            {
                conn.Open();
                comm.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }

            return true;
        }
    }
}
