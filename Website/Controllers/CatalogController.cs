using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Domain.Models;

namespace Website.Controllers
{
    public class CatalogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Ride(Vehicle vehicle)
        {
            return View("Ride", vehicle);
        }
    }
}
