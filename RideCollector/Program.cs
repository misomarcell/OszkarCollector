using System;
using System.Collections.Generic;
using System.Text;

namespace RideCollector
{
    class Program
    {
        public static void Main(string[] args)
        {
            var manager = new Collector();

            manager.LoadPages();
        }
    }
}
