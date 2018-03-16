﻿using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collector.Pages
{
    internal class ListPage
    {
        public Uri NextPage { get;}
        public HtmlDocument Document { get; }
        public List<Uri> Rides { get; }

        public ListPage(HtmlDocument document)
        {
            Document = document;
            NextPage = GetNextPage();
            Rides = GetRides();

            Document = null;
        }

        private Uri GetNextPage()
        {
            var pagination = Document.DocumentNode.SelectSingleNode("//div[@class='pagination center ']");
            var activePage = pagination.SelectSingleNode("//li[@class='active']");
            var nextPage = activePage.NextSibling.NextSibling.FirstChild.GetAttributeValue("href", String.Empty);

            return new Uri(nextPage);
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
