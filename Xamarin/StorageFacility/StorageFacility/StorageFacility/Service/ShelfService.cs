using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using StorageFacility.DTO;

namespace StorageFacility.Service
{
    class ShelfService : IShelfService
    {
        static HttpClient client;

        static string HostName = EnvironmentFactory.GetHostNameLocation();

        public ShelfService()
        {
            client = EnvironmentFactory.GetHttpClient();
        }

        /// <summary>
        /// Adds a product to a shelf, based on the parameters
        /// if it works returns true, otherwise false
        /// </summary>
        /// <param name="rackName"></param>
        /// <param name="shelfName"></param>
        /// <param name="barcode"></param>
        /// <returns></returns>
        public async Task<bool> AddProductToShelf(string rackName, string shelfName, string barcode)
        {
            HttpResponseMessage response = await client.PostAsync(
                string.Format("{0}/api/Shelf/AddToShelf?rackName={1}&shelfName={2}&barcode={3}", HostName, rackName, shelfName, barcode), null);

            response.EnsureSuccessStatusCode();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Creates a shelf, from the inputs of the parameters
        /// Using the API
        /// </summary>
        /// <param name="name"></param>
        /// <param name="rackName"></param>
        /// <returns></returns>
        public async Task<bool> CreateShelf(string name, string rackName)
        {
            HttpResponseMessage response = await client.PostAsync(
                string.Format("{0}/api/Shelf?name={1}&rackName={2}", HostName, name, rackName), null);
            response.EnsureSuccessStatusCode();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<List<ShelfProductAmount>> GetProductsFromBarcode(string productBarcode)
        {
            HttpResponseMessage response = await client.GetAsync(
                string.Format("{0}/api/Shelf/find/product?productID={1}", HostName, productBarcode));
            response.EnsureSuccessStatusCode();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                 return JArray.Parse(response.Content.ReadAsStringAsync().Result).ToObject<List<ShelfProductAmount>>();
            }
            else
            {
                return new List<ShelfProductAmount>();
             }
        }
        
        /// <summary>
        /// Gets the shelves from the API
        /// Returns a list of shelves
        /// </summary>
        /// <returns></returns>
        public async Task<List<Shelf>> GetShelves()
        {
            HttpResponseMessage response = await client.GetAsync(string.Format("{0}/api/Shelf", HostName));
            response.EnsureSuccessStatusCode();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                List<Shelf> racks = JArray.Parse(response.Content.ReadAsStringAsync().Result).ToObject<List<Shelf>>();
                return racks;
            }
            else
            {
                return null;
            }
        }
    }
}
