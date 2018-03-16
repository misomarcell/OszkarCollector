using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Collector;
using Collector.Pages;

namespace Website.Api.v1
{
    [Produces("application/json")]
    [Route("api/v1/rides")]
    public class RidesController : Controller
    {
        public RidesManager ridesManager { get; set; }

        public RidesController()
        {
            ridesManager = new RidesManager();
        }

        [HttpGet]
        public List<string> Get()
        {
            var pages = ridesManager.GetPages();
            var list = new List<string>();
            foreach (var item in pages)
            {
                list.Add(item.Vehicle.ToString());
            }
            return list;
        }
    }
}