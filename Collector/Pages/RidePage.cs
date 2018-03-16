using HtmlAgilityPack;
using OszkarCollector.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collector.Pages
{
    class RidePage
    {
        public HtmlDocument Document { get; }
        public Uri PageUri { get;}
        public string Vehicle { get; }
        public string Price { get; }
        public Driver Driver { get; }

        public RidePage(HtmlDocument document, Uri pageUri)
        {
            Document = document;
            PageUri = pageUri;
            Vehicle = GetVehicleName();
            Price = GetPrice();
            Driver = GetDriver();
        }

        private string GetVehicleName()
        {
            var vehicleTitle = Document.DocumentNode.SelectSingleNode("//dt[text()='Gépjármű:']");
            var vehicleName = vehicleTitle.NextSibling.NextSibling.InnerText.Trim();

            return vehicleName;
        }

        private string GetPrice()
        {
            var priceTitle = Document.DocumentNode.SelectSingleNode("//dt[text()='Az utazás díja:']");
            var price = priceTitle.NextSibling.NextSibling.InnerText.Replace("/ fő", String.Empty).Replace("&", String.Empty).Trim();

            return price;
        }

        private Driver GetDriver()
        {
            var driverTitle = Document.DocumentNode.SelectSingleNode("//dt[text()='A hirdető:']");
            var driverName = driverTitle.NextSibling.NextSibling.InnerText.Trim();
            var driverPage = driverTitle.NextSibling.NextSibling.FirstChild.GetAttributeValue("href", String.Empty);

            return new Driver(driverName, new Uri(driverPage));
        }
    }    
}
