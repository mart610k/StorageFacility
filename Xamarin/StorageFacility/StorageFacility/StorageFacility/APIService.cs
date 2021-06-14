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
                string.Format("{0}/api/Rack?name={1}",HostName,name), null);
            response.EnsureSuccessStatusCode();

            if(response.StatusCode == HttpStatusCode.OK)
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
