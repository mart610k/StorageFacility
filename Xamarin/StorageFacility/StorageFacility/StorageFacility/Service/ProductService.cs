﻿using System;
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

    }
}
