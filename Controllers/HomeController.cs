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
     

        public IActionResult Resource()
        {
            return View();
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
