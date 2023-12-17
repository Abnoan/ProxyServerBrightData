namespace BrightDataProxy
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            // Bright Data Proxy Configuration
            string host = "zproxy.lum-superproxy.io";
            int port = 22225;
            string username = "your_username";
            string password = "your_password";
            var client = BrightDataProxyConfigurator.ConfigureHttpClient(host, port, username, password);

            // Scrape content from the target URL
            string urlToScrape = "https://www.wikipedia.org/";
            var content = await WebContentScraper.ScrapeContent(urlToScrape, client);

            // Extract data from the HTML content
            HtmlDataExtractor.ExtractHyperlinks(content);
        }
    }
}