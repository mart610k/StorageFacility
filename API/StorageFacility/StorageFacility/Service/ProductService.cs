using MySql.Data.MySqlClient;
using StorageFacility.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StorageFacility.DTO;

namespace StorageFacility.Service
{
    public class ProductService : IProductService
    {
        IDatabaseConnection databaseConnection;

        public ProductService(IDatabaseConnection databaseConnection)
        {
            this.databaseConnection = databaseConnection;
        }

        public List<Product> GetProducts()
        {
            List<Product> products = new List<Product>();
            MySqlConnection conn = new MySqlConnection(databaseConnection.GetConnectionString());

            MySqlCommand comm = conn.CreateCommand();

            comm.CommandText = "Select Name, Barcode from Product";

            try
            {
                conn.Open();
                MySqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    products.Add(new Product(reader.GetUInt64("Barcode").ToString(), reader.GetString("Name")));
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

            return products;
        }


        public bool Register(ulong barcode, string name)
        {
            MySqlConnection conn = new MySqlConnection(databaseConnection.GetConnectionString());

            MySqlCommand comm = conn.CreateCommand();

            comm.CommandText = "INSERT INTO Product(`Barcode`,`Name`) Value (@barcode,@name);";

            comm.Parameters.AddWithValue("@barcode", barcode);
            comm.Parameters.AddWithValue("@name", name);

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
