using HtmlAgilityPack;
using Models.Pages;
using Models.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositories;

namespace Collector
{
    public class RidesManager
    {
        private const string HOMEPAGE_URL = "https://utitars.oszkar.com/hely-1/";

        MySqlRepository Repository = new MySqlRepository();
        HtmlWeb htmlWeb = new HtmlWeb();

        public RidesManager()
        {
            //Task.Run(() => LoadPages());
        }

        public void LoadPages()
        {
            ListPage listPage = new ListPage(htmlWeb.Load(HOMEPAGE_URL));

            while (listPage.NextPage != null)
            {
                foreach (var link in listPage.Rides)
                {
                    RidePage ridePage = new RidePage(htmlWeb.Load(link), link);

                    Repository.AddRide(ridePage);
                    Console.WriteLine(ridePage.Vehicle.ToString());
                }

                listPage = new ListPage(htmlWeb.Load(listPage.NextPage));
            }

            Console.ReadKey();
        }

    }
}
