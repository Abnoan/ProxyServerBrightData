using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebScrapApp
{
    public class WebScraper
    {
        public static async Task ScrapeData(ProxyRotator proxyRotator, string url)
        {
            try
            {
                var client = proxyRotator.ScrapeDataWithRandomProxy(url);

                // Use HttpClient to make an asynchronous GET request
                var response = await client.GetAsync(url);
                var content = await response.Content.ReadAsStringAsync();

                // Load the HTML content into an HtmlDocument
                HtmlDocument doc = new();
                doc.LoadHtml(content);

                // Use XPath to find all <a> tags that are direct children of <li>, <p>, or <td>
                var nodes = doc.DocumentNode.SelectNodes("//li/a[@href] | //p/a[@href] | //td/a[@href]");

                if (nodes != null)
                {
                    foreach (var node in nodes)
                    {
                        string hrefValue = node.GetAttributeValue("href", string.Empty);
                        string title = node.InnerText; // This gets the text content of the <a> tag, which is usually the title

                        // Since Wikipedia URLs are relative, we need to convert them to absolute
                        Uri baseUri = new(url);
                        Uri fullUri = new(baseUri, hrefValue);

                        Console.WriteLine($"Title: {title}, Link: {fullUri.AbsoluteUri}");
                        // You can process each title and link as required
                    }
                }
                else
                {
                    Console.WriteLine("No article links found on the page.");
                }

                // Add additional logic for other data extraction as needed
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Method to check if a proxy is working
        public static async Task<bool> IsProxyWorking(HttpClient client)
        {
            try
            {
                // Try a simple request to a known URL
                var testUrl = "http://www.google.com";
                var response = await client.GetAsync(testUrl);

                // Check if the response status code is 200 OK
                return response.IsSuccessStatusCode;
            }
            catch
            {
                // If any exceptions are thrown, the proxy is likely not working
                return false;
            }
        }
    }
}