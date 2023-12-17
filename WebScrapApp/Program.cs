namespace WebScrapApp
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            // Define your list of proxy URLs
            string[] _proxies = {
                                        "http://192.118.34.218:80",
                                        "http://193.239.56.84:8081",
                                        "http://94.45.74.60:8080",
                                        "http://162.248.225.8:80",
                                        "http://167.71.5.83:3128"
                                    };
       
            var proxyRotator = new ProxyRotator(_proxies);
            string urlToScrape = "https://www.wikipedia.org/";  // Replace with your target URL

            await WebScraper.ScrapeData(proxyRotator, urlToScrape);
        }
    }
}