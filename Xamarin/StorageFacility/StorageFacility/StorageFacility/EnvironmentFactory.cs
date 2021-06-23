using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace StorageFacility
{
    class EnvironmentFactory
    {
        /// <summary>
        /// Gets the Hostname location
        /// </summary>
        /// <returns>string containing the hostname</returns>
        public static string GetHostNameLocation()
        {
            return "https://localhost:44398";
            //return "https://test.baage-it.dk";
        }

        /// <summary>
        /// If the SSL verification should be checked
        /// </summary>
        /// <returns>false means no check</returns>
        public static bool EnforceSSLVerification()
        {
            if (GetHostNameLocation().Contains("localhost"))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Creates a Httpclient based on the result of EnforceVerification
        /// </summary>
        /// <returns>httpclient prepared to access the api as expected</returns>
        public static HttpClient GetHttpClient()
        {
            if (!EnforceSSLVerification())
            {
                HttpClientHandler httpClientHandler = new HttpClientHandler();
                httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicyErrors) =>
                {
                    return true;
                };
                return new HttpClient(httpClientHandler);
            }
            return new HttpClient();
        }
    }
}
