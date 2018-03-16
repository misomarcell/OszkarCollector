using HtmlAgilityPack;
using Collector.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Collector
{
    class Program
    {
        private const string HOMEPAGE_URL = "https://utitars.oszkar.com/hely-1/";

        private static HtmlWeb htmlWeb = new HtmlWeb();
        static void Main(string[] args)
        {
            ListPage listPage = new ListPage(htmlWeb.Load(HOMEPAGE_URL));

            var count = 0;
            while (listPage.NextPage != null)
            {
                foreach (var link in listPage.GetRides())
                {
                    RidePage ridePage = new RidePage(htmlWeb.Load(link), link);

                    count++;
                    Console.WriteLine($"{count}) {ridePage.Vehicle} - {ridePage.Price}");
                }

                listPage = new ListPage(htmlWeb.Load(listPage.NextPage));
            }

            

            Console.ReadKey();
        }

    }
}
