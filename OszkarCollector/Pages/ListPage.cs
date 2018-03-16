using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OszkarCollector.Pages
{
    internal class ListPage
    {
        public Uri NextPage { get; private set; }
        public HtmlDocument Document { get; set; }

        public ListPage(HtmlDocument document)
        {
            Document = document;
            NextPage = GetNextPage();
        }

        private Uri GetNextPage()
        {
            var pagination = Document.DocumentNode.SelectSingleNode("//div[@class='pagination center ']");
            var activePage = pagination.SelectSingleNode("//li[@class='active']");
            var nextPage = activePage.NextSibling.NextSibling.FirstChild.GetAttributeValue("href", String.Empty);

            return new Uri(nextPage);
        }

        public List<Uri> GetRides()
        {
            var links = new List<Uri>();
            foreach (HtmlNode link in Document.DocumentNode.SelectNodes("//meta[@itemprop='url']"))
            {
                string hrefValue = link.GetAttributeValue("content", string.Empty);
                if (hrefValue.Contains("/telekocsi/"))
                    links.Add(new Uri(hrefValue));
            }

            return links;
        }
    }
}
