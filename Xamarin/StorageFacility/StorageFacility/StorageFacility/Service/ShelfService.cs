using Newtonsoft.Json.Linq;
using StorageFacility.Class;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StorageFacility.Service
{
    class ShelfService : IShelfService
    {
        static HttpClient client = new HttpClient();
        static string HostName = "https://test.baage-it.dk";

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
