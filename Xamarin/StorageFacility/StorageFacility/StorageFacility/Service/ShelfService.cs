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
        private HttpClient client;

        private string hostName = EnvironmentFactory.GetHostNameLocation();

        public ShelfService()
        {
            hostName = EnvironmentFactory.GetHostNameLocation();
            client = EnvironmentFactory.GetHttpClient();
        }

        public async Task<bool> AddProductAmount(string rackName, string shelfName, string barcode, int amount)
        {
            HttpResponseMessage response = await client.PostAsync(
                string.Format("{0}/api/Shelf/AddAmount?rackName={1}&shelfName={2}&barcode={3}&amount={4}", hostName, rackName, shelfName, barcode, amount), null);

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

        public async Task<bool> AddProductToShelf(string rackName, string shelfName, string barcode)
        {
            HttpResponseMessage response = await client.PostAsync(
                string.Format("{0}/api/Shelf/AddToShelf?rackName={1}&shelfName={2}&barcode={3}", hostName, rackName, shelfName, barcode), null);

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

        public async Task<bool> CreateShelf(string name, string rackName)
        {
            HttpResponseMessage response = await client.PostAsync(
                string.Format("{0}/api/Shelf?name={1}&rackName={2}", hostName, name, rackName), null);
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
                string.Format("{0}/api/Shelf/find/product?productID={1}", hostName, productBarcode));
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

        public async Task<List<ShelfProductAmount>> GetProductAmount()
        {
            HttpResponseMessage response = await client.GetAsync(
                string.Format("{0}/api/Shelf/get/product", hostName));
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

        public async Task<List<Shelf>> GetShelves()
        {
            HttpResponseMessage response = await client.GetAsync(string.Format("{0}/api/Shelf", hostName));
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
