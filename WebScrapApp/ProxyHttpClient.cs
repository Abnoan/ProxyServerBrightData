using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WebScrapApp
{
    public class ProxyHttpClient
    {
        public static HttpClient CreateClient(string proxyUrl)
        {
            var httpClientHandler = new HttpClientHandler()
            {
                Proxy = new WebProxy(proxyUrl),
                UseProxy = true
            };
            return new HttpClient(httpClientHandler);
        }
    }
}
