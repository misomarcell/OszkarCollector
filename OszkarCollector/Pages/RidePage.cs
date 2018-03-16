using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OszkarCollector.Pages
{
    class RidePage
    {
        public HtmlDocument Document { get; set; }
        public Uri PageUri { get; set; }
        public string Vehicle { get; set; }
        public string Price { get; set; }

        public RidePage(HtmlDocument document, Uri pageUri)
        {
            Document = document;
            PageUri = pageUri;
            Vehicle = GetVehicleName();
            Price = GetPrice();
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
    }    
}
