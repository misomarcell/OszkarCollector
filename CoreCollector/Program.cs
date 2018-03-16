using System;

namespace Collector
{
    class Program
    {
        static void Main(string[] args)
        {
            var manager = new RidesManager();

            manager.LoadPages();
        }
    }
}