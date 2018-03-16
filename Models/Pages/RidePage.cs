using HtmlAgilityPack;
using Models.Objects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Pages
{
    public class RidePage
    {
        [JsonIgnore]
        public HtmlDocument Document { get; }
        public Uri PageUri { get; set; }
        public string Price { get; set; }
        public Vehicle Vehicle { get; set; }
        public Driver Driver { get; set; }

        public RidePage() { }

        public RidePage(HtmlDocument document, Uri pageUri)
        {
            Document = document;
            PageUri = pageUri;
            Vehicle = GetVehicle();
            Price = GetPrice();
            Driver = GetDriver();

            Document = null;
        }

        private Vehicle GetVehicle()
        {
            var vehicleTitle = Document.DocumentNode.SelectSingleNode("//dt[text()='Gépjármű:']");
            var vehicleName = vehicleTitle.NextSibling.NextSibling.InnerText.Trim();

            var brand = vehicleName.Split(" ".ToCharArray()[0]);
            var model = brand[1].Replace(",", "");
            int year = -1;
            int.TryParse(brand[brand.Length - 1], out year);

            return new Vehicle(brand[0], model, year);
        }

        private string GetPrice()
        {
            var priceTitle = Document.DocumentNode.SelectSingleNode("//dt[text()='Az utazás díja:']");
            var price = priceTitle.NextSibling.NextSibling.InnerText
                .Replace("/ fő", String.Empty)
                .Replace("&", String.Empty)
                .Replace(";", String.Empty)
                .Trim();

            return price;
        }

        private Driver GetDriver()
        {
            var driverTitle = Document.DocumentNode.SelectSingleNode("//dt[text()='A hirdető:']");
            var driverName = driverTitle.NextSibling.NextSibling.InnerText.Trim();
            var driverPage = driverTitle.NextSibling.NextSibling.FirstChild.GetAttributeValue("href", String.Empty);

            return new Driver(driverName, new Uri(driverPage));
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }    
}
