using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Pages
{
    public class CatalogPage
    {
        public Uri NextPage { get; }
        public HtmlDocument Document { get; }
        public List<Uri> Rides { get; }
        public int PageNumber { get; }

        public CatalogPage(HtmlDocument document)
        {
            Document = document;
            Rides = GetRides();
            PageNumber = GetPageNumber();
            try
            {
                NextPage = GetNextPage();
            }
            catch (Exception)
            {

                NextPage = null;
            }
            finally
            {
                Document = null;
            }   
        }

        private Uri GetNextPage()
        {
            var pagination = Document.DocumentNode.SelectSingleNode("//div[@class='pagination center ']");
            var activePage = pagination.SelectSingleNode("//li[@class='active']");
            var nextPage = activePage.NextSibling.NextSibling.FirstChild.GetAttributeValue("href", String.Empty);

            return new Uri(nextPage);
        }

        private int GetPageNumber()
        {
            var pagination = Document.DocumentNode.SelectSingleNode("//div[@class='pagination center ']");
            var activePage = pagination.SelectSingleNode("//li[@class='active']");

            return Convert.ToInt32(activePage.FirstChild.InnerText.Trim());
        }

        private List<Uri> GetRides()
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
