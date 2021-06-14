using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace StorageFacility.Classes
{
    public class RackService : IRackService
    {
        private IDatabaseConnection databaseConnection;
        private List<string> Racks = new List<string>();

        public RackService(IDatabaseConnection databaseConnection)
        {
            this.databaseConnection = databaseConnection;
        }

        public List<string> GetRacks()
        {
            MySqlConnection conn = new MySqlConnection(databaseConnection.GetConnectionString());

            MySqlCommand comm = conn.CreateCommand();

            comm.CommandText = "Select Name from Rack;";

            try
            {
                conn.Open();
                MySqlDataReader reader = comm.ExecuteReader();
                while(reader.Read())
                {
                    Racks.Add(reader.GetString("Name"));
                }


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

            return Racks;
        }

        public bool Register(string rackname)
        {
            MySqlConnection conn = new MySqlConnection(databaseConnection.GetConnectionString());

            MySqlCommand comm = conn.CreateCommand();

            comm.CommandText = "INSERT INTO Rack(`Name`) Value (@name);";

            comm.Parameters.AddWithValue("@name", rackname);

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
