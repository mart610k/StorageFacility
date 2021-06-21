using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace StorageFacility
{
    class EnvironmentFactory
    {

        public static string GetHostNameLocation()
        {
            //return "https://localhost:44398";
            return "https://test.baage-it.dk";
        }

        public static bool EnforceSSLVerification()
        {
            if (GetHostNameLocation().Contains("localhost"))
            {
                return false;
            }

            return true;
        }

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
