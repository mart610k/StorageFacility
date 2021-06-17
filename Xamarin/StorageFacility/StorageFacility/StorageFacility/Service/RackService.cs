using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;

namespace StorageFacility.Service
{
    class RackService : IRackService
    {
        // HTTP Client
        // HostName String
        static HttpClient client = new HttpClient();
        static string HostName = "https://test.baage-it.dk";

        /// <summary>
        /// Sends a post to the API, to create a Rack. Based around the parameter
        /// Chekcs whether the HTTPStatusCode is OK
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Sends a Get to the API, to get all the rakcs from the API
        /// Returns a list based on the API return
        /// </summary>
        /// <returns></returns>
        public async Task<List<string>> GetRacks()
        {
            HttpResponseMessage response = await client.GetAsync(
                string.Format("{0}/api/Rack", HostName));
            response.EnsureSuccessStatusCode();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                List<string> racks = JArray.Parse(response.Content.ReadAsStringAsync().Result).ToObject<List<string>>();
                return racks;
            }
            else
            {
                return null;
            }
        }
    }
}
