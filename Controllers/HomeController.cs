using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjectForHealing.Models;

namespace ProjectForHealing.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        [HttpGet]
        public IActionResult ResourceForm()
        {
            using (var context = new CRMSContext())
            {
                // find 1 by primary key
               // var resource = context.Resource.Find(1);
                // get all
                // var resources = context.Resource.All(i => true);
            }

            var model = new Resource();

            return View(model);
        }
        [HttpPost]
        public IActionResult ResourceForm(Resource model)
        {
            ModelState.AddModelError("", "Not writing to database yet");


            using (var context = new CRMSContext()) 
            {
                // insert new resource
               // context.Resource.Add(model);
            }

             return View(model);
        }

        public IActionResult Login()
        {
            return View();
        }
        public IActionResult ResourceManage()
        {
            return View();
        }

        public IActionResult ModelDemo()
        {
            var model = new ModelDemoModel()
            {
                FName = "Khalil",
                LName = "McCall",
                IsEmployee = true

            };
            return View(model);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
