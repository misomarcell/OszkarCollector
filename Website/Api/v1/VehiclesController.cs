using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories;
using Newtonsoft.Json;
using Domain.Pages;
using Domain.Models;

namespace Website.Api.v1
{
    [Produces("application/json")]
    [Route("api/v1/vehicles")]
    public class VehiclesController : Controller
    {
        IRepository Repository;

        public VehiclesController()
        {
            Repository = new MySqlRepository();
        }

        [HttpGet]
        public Dictionary<Vehicle, int> Get(int page = 0)
        {
            var rides = Repository.GetVehicles(page);
            return rides;
        }
    }
}