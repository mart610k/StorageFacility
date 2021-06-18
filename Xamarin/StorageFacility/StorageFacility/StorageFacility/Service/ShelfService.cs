using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
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

        public async Task<List<ShelfProductAmount>> GetProductsFromBarcde(string productBarcode)
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
    }
}
