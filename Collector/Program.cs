using HtmlAgilityPack;
using OszkarCollector;
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
        public static void Main(string[] args)
        {
            var manager = new RidesManager();

            manager.LoadPages();
        }
    }
}
