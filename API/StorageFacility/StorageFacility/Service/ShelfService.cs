using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StorageFacility.Classes;
using StorageFacility.DTO;

namespace StorageFacility.Service
{
    public class ShelfService : IShelfService
    {
        private IDatabaseConnection databaseConnection;

        public ShelfService(IDatabaseConnection databaseConnection)
        {
            this.databaseConnection = databaseConnection;
        }

        /// <summary>
        /// Get's a list of shelf's that contains a product with parameter id
        /// </summary>
        /// <param name="productID"></param>
        /// <returns></returns>
        public List<ShelfProductAmount> GetShelvesContainingProductByID(string productID)
        {
            List<ShelfProductAmount> shelfProductAmounts = new List<ShelfProductAmount>();

            MySqlConnection conn = new MySqlConnection(databaseConnection.GetConnectionString());

            MySqlCommand comm = conn.CreateCommand();
            comm.CommandText = "Select `Rack_Name`,`Shelf_Name`,`Product_BC`,`Amount`,`Name` from Shelf_Product_Amount Join Product on Shelf_Product_Amount.Product_BC = Product.Barcode WHERE Product_BC = @Barcode;";

            try
            {
                ulong productIDULong = ulong.Parse(productID);

                comm.Parameters.AddWithValue("@Barcode", productIDULong);
                conn.Open();
                MySqlDataReader reader = comm.ExecuteReader();

                while (reader.Read())
                {
                    Shelf shelf = new Shelf(reader.GetString("Shelf_Name"), reader.GetString("Rack_Name"));
                    Product product = new Product(reader.GetUInt64("Product_BC").ToString(), reader.GetString("Name"));

                    ShelfProductAmount shelfProductAmount = new ShelfProductAmount(shelf, product, reader.GetByte("Amount"));

                    shelfProductAmounts.Add(shelfProductAmount);
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
            return shelfProductAmounts;
        }

        public List<ShelfProductAmount> GetShelfProductAmounts()
        {
            List<ShelfProductAmount> shelfProductAmounts = new List<ShelfProductAmount>();

            MySqlConnection conn = new MySqlConnection(databaseConnection.GetConnectionString());

            MySqlCommand comm = conn.CreateCommand();
            comm.CommandText = "Select `Rack_Name`,`Shelf_Name`,`Product_BC`,`Amount`,`Name` from Shelf_Product_Amount Join Product on Shelf_Product_Amount.Product_BC = Product.Barcode;";

            try
            {
                conn.Open();
                MySqlDataReader reader = comm.ExecuteReader();

                while (reader.Read())
                {
                    Shelf shelf = new Shelf(reader.GetString("Shelf_Name"), reader.GetString("Rack_Name"));
                    Product product = new Product(reader.GetUInt64("Product_BC").ToString(), reader.GetString("Name"));

                    ShelfProductAmount shelfProductAmount = new ShelfProductAmount(shelf, product, reader.GetByte("Amount"));

                    shelfProductAmounts.Add(shelfProductAmount);
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
            return shelfProductAmounts;
        }


        /// <summary>
        /// Adds a product to a shelf, based on the 3 parameters
        /// The Rack
        /// The Shelf 
        /// The Product Barcode
        /// </summary>
        /// <param name="rackName"></param>
        /// <param name="shelfName"></param>
        /// <param name="barcode"></param>
        /// <returns></returns>
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

            comm.CommandText = "UPDATE Shelf_Product_Amount SET `Amount` = `Amount` - @amount WHERE(`Product_BC` = @productBC) AND (`Rack_Name` = @rackName) AND (`Shelf_Name` = @shelfName);";

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
            comm.CommandText = "UPDATE Shelf_Product_Amount SET `Amount` = `Amount` + @amount WHERE(`Product_BC` = @productBC) AND (`Rack_Name` = @rackName) AND (`Shelf_Name` = @shelfName);";

            comm.Parameters.AddWithValue("@rackName", rackName);
            comm.Parameters.AddWithValue("@shelfName", shelfName);
            comm.Parameters.AddWithValue("@productBC", barcode);
            comm.Parameters.AddWithValue("@amount", Convert.ToByte(amount));

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

        public List<Shelf> GetShelves()
        {
            List<Shelf> shelves = new List<Shelf>();

            MySqlConnection conn = new MySqlConnection(databaseConnection.GetConnectionString());

            MySqlCommand comm = conn.CreateCommand();

            comm.CommandText = "Select Name, Rack_Name from Shelf";

            try
            {
                conn.Open();
                MySqlDataReader reader = comm.ExecuteReader();

                while (reader.Read())
                {
                    shelves.Add(new Shelf(reader.GetString("Name"), reader.GetString("Rack_Name")));
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

            return shelves;
        }
    }
}
