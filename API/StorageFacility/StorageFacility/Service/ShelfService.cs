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
        List<string> shelves = new List<string>();

        public ShelfService(IDatabaseConnection databaseConnection)
        {
            this.databaseConnection = databaseConnection;
        }

        public bool AddProductToShelf(string rackName, string shelfName, string barcode)
        {
            MySqlConnection conn = new MySqlConnection(databaseConnection.GetConnectionString());

            MySqlCommand comm = conn.CreateCommand();

            comm.CommandText = "INSERT INTO Shelf_Product_Amount(`Rack_Name`, `Shelf_Name`, `Product_BC`, `Amount`) Value (@rackName, @shelfName, @productBC, @amount);";

            comm.Parameters.AddWithValue("@rackName", rackName);
            comm.Parameters.AddWithValue("@shelfName", shelfName);
            comm.Parameters.AddWithValue("@productBC", barcode);
            comm.Parameters.AddWithValue("@amount", 0);

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

        public bool RemoveProductAmount(string rackName, string shelfName, string barcode, int amount)
        {
            MySqlConnection conn = new MySqlConnection(databaseConnection.GetConnectionString());

            MySqlCommand comm = conn.CreateCommand();

            comm.CommandText = "UPDATE SET Shelf_Product_Amount(`Amount`= `Amount` - @amount) WHERE (`Rack_Name`, `Shelf_Name`, `Product_BC`) Value (@rackName, @shelfName, @productBC);";

            comm.Parameters.AddWithValue("@rackName", rackName);
            comm.Parameters.AddWithValue("@shelfName", shelfName);
            comm.Parameters.AddWithValue("@productBC", barcode);
            comm.Parameters.AddWithValue("@amount", amount);

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
        public bool AddProductAmount(string rackName, string shelfName, string barcode, int amount)
        {
            MySqlConnection conn = new MySqlConnection(databaseConnection.GetConnectionString());

            MySqlCommand comm = conn.CreateCommand();

            comm.CommandText = "UPDATE SET Shelf_Product_Amount(`Amount`= `Amount` + @amount) WHERE (`Rack_Name`, `Shelf_Name`, `Product_BC`) Value (@rackName, @shelfName, @productBC);";

            comm.Parameters.AddWithValue("@rackName", rackName);
            comm.Parameters.AddWithValue("@shelfName", shelfName);
            comm.Parameters.AddWithValue("@productBC", barcode);
            comm.Parameters.AddWithValue("@amount", amount);

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

        public List<string> GetShelves()
        {
            MySqlConnection conn = new MySqlConnection(databaseConnection.GetConnectionString());

            MySqlCommand comm = conn.CreateCommand();

            comm.CommandText = "Select Name, Rack_Name from Shelf";

            try
            {
                conn.Open();
                MySqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {

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

            return null;
        }
    }
}
