using RideCollector;
using Domain.Pages;
using HtmlAgilityPack;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideCollector
{
    public class Collector
    {
        // /pageexact-1000
        private const string HOMEPAGE_URL = "https://utitars.oszkar.com/hely-1/";

        MySqlRepository Repository = new MySqlRepository();
        HtmlWeb htmlWeb = new HtmlWeb();

        public Collector() { }

        public void LoadPages()
        {
            CatalogPage listPage = new CatalogPage(htmlWeb.Load(HOMEPAGE_URL));

            Repository.Clean();

            var prevPageNumber = 0;
            while (listPage.PageNumber > prevPageNumber)
            {
                foreach (var link in listPage.Rides)
                {
                    RidePage ridePage = new RidePage(htmlWeb.Load(link), link);  

                    var index = Repository.AddRide(ridePage);
                    Console.WriteLine($"{index}) " + ridePage.Vehicle.ToString());
                }

                prevPageNumber = listPage.PageNumber;
                listPage = new CatalogPage(htmlWeb.Load(listPage.NextPage));
            }

            Console.WriteLine("No more pages found. Press any key to exit...");
            Console.ReadKey();
        }

    }
}
