using Collector;
using HtmlAgilityPack;
using Models.Pages;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OszkarCollector
{
    public class RidesManager
    {
        private const string HOMEPAGE_URL = "https://utitars.oszkar.com/hely-1/";

        MySqlRepository Repository = new MySqlRepository();
        HtmlWeb htmlWeb = new HtmlWeb();

        public RidesManager() { }

        public void LoadPages()
        {
            ListPage listPage = new ListPage(htmlWeb.Load(HOMEPAGE_URL));

            while (listPage.NextPage != null)
            {
                foreach (var link in listPage.Rides)
                {
                    RidePage ridePage = new RidePage(htmlWeb.Load(link), link);

                    var index = Repository.AddRide(ridePage);
                    Console.WriteLine($"{index}) " + ridePage.Vehicle.ToString());
                }

                listPage = new ListPage(htmlWeb.Load(listPage.NextPage));
            }

            Console.ReadKey();
        }

    }
}
