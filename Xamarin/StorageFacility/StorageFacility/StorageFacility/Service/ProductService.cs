using Newtonsoft.Json.Linq;
using StorageFacility.Class;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace StorageFacility.Service
{
    class ProductService : IProductService
    {
        static HttpClient client;

        static string HostName = EnvironmentFactory.GetHostNameLocation();

        public ProductService()
        {
            client = EnvironmentFactory.GetHttpClient();
        }



        /// <summary>
        /// Creates a product with specified Parameters
        /// From Api Post
        /// </summary>
        /// <param name="name"></param>
        /// <param name="barcode"></param>
        /// <returns></returns>
        public async Task<bool> CreateProduct(string name, string barcode)
        {
            string link = string.Format(
                    "{0}/api/Product?name={1}&barcode={2}",
                    HostName,
                    name,
                    barcode);


            HttpResponseMessage response = await client.PostAsync(
                 link
                , null);

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
        /// Get's the products from the API
        /// Returns a list of products
        /// </summary>
        /// <returns></returns>
        public async Task<List<Product>> GetProducts()
        {
            HttpResponseMessage response = await client.GetAsync(string.Format("{0}/api/Product", HostName));
            response.EnsureSuccessStatusCode();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                List<Product> products = JArray.Parse(response.Content.ReadAsStringAsync().Result).ToObject<List<Product>>();
                return products;
            }
            else
            {
                return null;
            }
        }

    }
}
