using Collector;
using Collector.Pages;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collector
{
    public class RidesManager
    {
        private const string HOMEPAGE_URL = "https://utitars.oszkar.com/hely-1/";

        List<RidePage> pages = new List<RidePage>();
        HtmlWeb htmlWeb = new HtmlWeb();

        public RidesManager()
        {
            Task.Run(() => LoadPages());
        }

        public async void LoadPages()
        {
            ListPage listPage = new ListPage(htmlWeb.Load(HOMEPAGE_URL));

            // var count = 0;
            while (listPage.NextPage != null)
            {
                foreach (var link in listPage.Rides)
                {
                    RidePage ridePage = new RidePage(htmlWeb.Load(link), link);

                    pages.Add(ridePage);
                    //count++;
                    //Console.WriteLine($"{count}) {ridePage.Vehicle.ToString()} \t {ridePage.Price}");
                }

                listPage = new ListPage(htmlWeb.Load(listPage.NextPage));
            }

            Console.ReadKey();
        }

        public List<RidePage> GetPages()
        {
            return pages;
        }
    }
}
