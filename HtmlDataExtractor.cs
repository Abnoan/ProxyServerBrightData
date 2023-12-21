using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebScrapBrightData
{
    public class HtmlDataExtractor
    {
        public static void ExtractHyperlinks(string htmlContent)
        {
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(htmlContent);

            var anchorTags = doc.DocumentNode.SelectNodes("//a");
            if (anchorTags != null)
            {
                foreach (var link in anchorTags)
                {
                    string hrefValue = link.GetAttributeValue("href", string.Empty);
                    Console.WriteLine(hrefValue);
                }
            }
            else
            {
                Console.WriteLine("No hyperlinks found.");
            }
        }
    }

}
