using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http.Headers;

namespace StorageFacility
{
    class APIService
    {

        static HttpClient client = new HttpClient();
        static string HostName = "https://test.baage-it.dk";

        public async Task<bool> CreateRack(string name)
        {
            HttpResponseMessage response = await client.PostAsync(
                string.Format("{0}/api/Rack?name={1}", HostName, name), null);
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

        public async Task<List<string>> GetRacks()
        {
            HttpResponseMessage response = await client.GetAsync(
                string.Format("{0}/api/Rack", HostName));
            response.EnsureSuccessStatusCode();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                List<string> Racks = new List<string>();
                Racks.Add(response.Content.ReadAsStringAsync().Result);
                return Racks ;
            }
            else
            {
                return null;
            }
        }
    }
}
