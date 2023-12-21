namespace WebScrapApp
{
    public class ProxyRotator
    {
        private readonly List<string> _validProxies;
        private readonly Random _random = new();

        public ProxyRotator(string[] proxies)
        {
            _validProxies = ProxyChecker.GetWorkingProxies(proxies.ToList()).Result;
            if (_validProxies.Count == 0)
                throw new InvalidOperationException();
        }

        public HttpClient ScrapeDataWithRandomProxy(string url)
        {
            if (_validProxies.Count == 0)
                throw new InvalidOperationException();

            var proxyUrl = _validProxies[_random.Next(_validProxies.Count)];
            return ProxyHttpClient.CreateClient(proxyUrl);
        }
    }
}
