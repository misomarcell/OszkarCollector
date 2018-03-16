using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Collector;
using Models.Pages;
using Repositories;
using Newtonsoft.Json;

namespace Website.Api.v1
{
    [Produces("application/json")]
    [Route("api/v1/rides")]
    public class RidesController : Controller
    {
        IRepository Repository;

        public RidesController()
        {
            Repository = new MySqlRepository();
        }

        [HttpGet]
        public List<RidePage> Get(int page = 0)
        {
            var rides = Repository.GetRides(page);
            return rides;
        }
    }
}