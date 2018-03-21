using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models;
using Domain.Pages;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories;

namespace Website.Api.v1
{
    [Produces("application/json")]
    [Route("api/v1/rides")]
    public class RidesController : Controller
    {
        [HttpGet]
        public List<RidePage> Get(Vehicle vehicle, int page = 0)
        {
            var repository = new MySqlRepository();

            return repository.GetVehicleRides(page, vehicle);
        }
    }
}