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
