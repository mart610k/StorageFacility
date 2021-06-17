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
    }
}
