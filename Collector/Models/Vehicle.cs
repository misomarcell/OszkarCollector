using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OszkarCollector.Models
{
    class Vehicle
    {
        public string Brand { get; }
        public string Model { get; set; }
        public int Year { get; set; }

        public Vehicle(string brand, string model, int year)
        {
            Brand = brand;
            Model = model;
            Year = year;     
        }

        public override string ToString()
        {
            return $"{Year} {Brand} {Model}";
        }
    }
}
