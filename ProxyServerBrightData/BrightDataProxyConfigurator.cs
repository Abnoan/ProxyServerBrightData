using System.Net;

namespace WebScrapBrightData
{
    public class BrightDataProxyConfigurator
    {
        public static HttpClient ConfigureHttpClient(string host, int port, string username, string password)
        {
            var proxyUrl = $"http://{username}:{password}@{host}:{port}";
            var httpClientHandler = new HttpClientHandler
            {
                Proxy = new WebProxy(proxyUrl),
                UseProxy = true
            };

            return new HttpClient(httpClientHandler);
        }
    }
}

