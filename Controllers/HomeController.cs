using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CarsAPI.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index(string brand, int year, string color = "black")
        {
            return Content($"Brand:{brand}, year: {year}, color: {color}");
        }
    }
}